using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody2D AttachedRigidbody;
        private void Start()
        {
            StartCoroutine(DesactivateMe_Coroutine());

            AttachedRigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                KillBullet();
                Destroy(collision.gameObject);
            }
        }

        private void KillBullet()
        {
            this.gameObject.SetActive(false);
        }

        private IEnumerator DesactivateMe_Coroutine()
        {
            yield return new WaitForSeconds(2f);

            this.gameObject.SetActive(false);
        }
    }
}