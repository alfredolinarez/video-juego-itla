using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class BulletPool : Singleton<BulletPool>
    {
        [SerializeField] private int _poolSize;
        [SerializeField] private Bullet _bulletPrefab;
        private List<Bullet> BulletsPool;
        private int _currentBulletIndex = 0;

        private void Awake()
        {
            #region Setting Up Singleton
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
                _instance = this;
            #endregion

            InitializePool();
        }

        public static Bullet GetBulletInPool
        {
            get
            {
                Bullet b = Instance.BulletsPool[Instance._currentBulletIndex];

                b.gameObject.SetActive(true);

                Instance._currentBulletIndex = (Instance._currentBulletIndex + 1) % Instance.BulletsPool.Count;

                return b;
            }
        }

        private void InitializePool()
        {
            BulletsPool = new List<Bullet>(_poolSize);

            for (int i = 0; i < _poolSize; i++)
            {
                Bullet currentBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

                BulletsPool.Add(currentBullet);

                currentBullet.gameObject.SetActive(false);

                currentBullet.transform.SetParent(this.transform);
            }
        }
    }
}