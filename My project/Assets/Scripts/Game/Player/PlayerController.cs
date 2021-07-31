using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f; 
        // Start is called before the first frame update
        void Start()
        {
            GameManager.Instance.Player = this;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector2.up * _speed * PlayerInput.MoveAxis * Time.deltaTime);
        }
    }
}