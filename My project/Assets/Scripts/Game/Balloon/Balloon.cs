using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class Balloon : MonoBehaviour {
        [SerializeField] public float MinSpeed = 1;
        [SerializeField] public float MaxSpeed = 1;
        private float _speed;

        [SerializeField] private int _pointsToGive = 1;
        [SerializeField] private List<Sprite> balloonSprites;

        void Start() {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = balloonSprites[Random.Range(0, balloonSprites.Count)];
            _speed = Random.Range(MinSpeed, MaxSpeed);
        }

        // Update is called once per frame
        void Update() {
            transform.Translate(Vector2.up * _speed * Time.deltaTime);
        }

        private void OnDestroy() {
            Score.Instance.UpdateScoreCount(_pointsToGive);
        }
    }
}