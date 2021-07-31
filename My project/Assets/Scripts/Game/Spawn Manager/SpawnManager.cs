using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game
{
    public class SpawnManager : Singleton<SpawnManager>
    {
        [SerializeField] private List<Wave> _waves;
        [Header("Spawn Point Reference")]
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _minX, _maxX;
        public Wave CurrentWave;
        private int _currentWaveIndex = 0;

        private void Awake()
        {
            if (_instance != this && _instance != null)
                Destroy(this.gameObject);
            else
                _instance = this;
        }

        private void Start()
        {
            StartSpawningWave(_waves[_currentWaveIndex]);

            GameManager.OnGameWin += StopAllCoroutines;
        }

        private void OnDisable()
        {
            GameManager.OnGameWin -= StopAllCoroutines;
        }

        public static void RemoveElementFromWave(string waveName, string elementName)
        {
            Wave wave = Instance._waves.Find(x => x.WaveName == waveName);

            Element element = wave.ObjectsToInstantiate.FindLast(x => x.Object.name == elementName);

            element.CurrentAmount--;

            if (element.CurrentAmount <= 0 && element.FinishedSpawning)
            {
                wave.ObjectsToInstantiate.Remove(element);
            }

            if (wave.ObjectsToInstantiate.Count == 0)
                Instance._waves.Remove(wave);
        }

        private void StartSpawningWave(Wave wave)
        {
            CurrentWave = wave;

            foreach (Element currentElement in wave.ObjectsToInstantiate)
            {
                StartCoroutine(InstantiateObject(currentElement.Object, currentElement.TimeToInstantiate, currentElement, wave));
            }
        }

        private IEnumerator InstantiateObject(GameObject obj, float time, Element element, Wave wave)
        {
            yield return new WaitForSeconds(time);

            for (int i = 0; i < element.TotalAmount; i++)
            {
                GameObject instance = Instantiate(obj,
                new Vector3(Random.Range(_minX, _maxX), _spawnPoint.position.y, _spawnPoint.position.z),
                Quaternion.identity);


                instance.transform.SetParent(wave.WaveContainer.transform);

                //Removes the prefab and places the exact object
                element.Object = instance;

                //Sets the waveName ID
                WaveElementController elementInstance = element.Object.AddComponent<WaveElementController>();
                elementInstance.WaveName = wave.WaveName;

                element.CurrentAmount++;

                if (element.CurrentAmount == element.TotalAmount)
                {
                    element.FinishedSpawning = true;

                    SelectNextWave();
                }

                yield return new WaitForSeconds(element.DelayBetweenThem);
            }
        }

        private void SelectNextWave()
        {
            if (CurrentWave == _waves[_waves.Count - 1])
                return;

            _currentWaveIndex = (_currentWaveIndex + 1) % _waves.Count;

            StartSpawningWave(_waves[_currentWaveIndex]);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_spawnPoint.position, .3f);

            Gizmos.color = Color.red;
            Vector3 minInstantiationPoint = new Vector3(_spawnPoint.position.x + _minX, _spawnPoint.position.y, _spawnPoint.position.z);
            Gizmos.DrawWireSphere(minInstantiationPoint, .3f);

            Gizmos.color = Color.green;
            Vector3 maxInstantiationPoint = new Vector3(_spawnPoint.position.x + _maxX, _spawnPoint.position.y, _spawnPoint.position.z);
            Gizmos.DrawWireSphere(maxInstantiationPoint, .3f);
        }
    }
}