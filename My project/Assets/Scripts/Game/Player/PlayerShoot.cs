using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed = 10f;
        [SerializeField] private float _fireRate = .5f;
        [SerializeField] private bool _canShoot = true;

        [Header("Spawn Point")]
        [SerializeField] private Transform _bulletsSpawnPoint;
        private void Update()
        {
            if (PlayerInput.ShootTriggered && _canShoot)
            {
                ShootBullet();
            }
        }

        public void ShootBullet()
        {
            Bullet currentBullet = BulletPool.GetBulletInPool;

            currentBullet.transform.position = _bulletsSpawnPoint.position;

            currentBullet.AttachedRigidbody.velocity = new Vector2(-_bulletSpeed, 0f);

            StartCoroutine(HandleShooting_Coroutine());
        }

        private IEnumerator HandleShooting_Coroutine()
        {
            _canShoot = false;
            yield return new WaitForSeconds(_fireRate);
            _canShoot = true;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.black;

            Gizmos.DrawWireSphere(_bulletsSpawnPoint.position, .2f);
        }
    }
}