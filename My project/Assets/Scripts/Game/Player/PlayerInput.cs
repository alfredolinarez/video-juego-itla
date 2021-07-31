using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerInput : Singleton<PlayerInput>
    {
        private void Awake()
        {
            if (_instance != this && _instance != null)
                Destroy(this.gameObject);
            else
                _instance = this;
        }

        public static float MoveAxis
        {
            get
            {
                return Input.GetAxisRaw("Vertical");
            }
        }

        public static bool ShootTriggered
        {
            get => Input.GetButton("Shoot");
        }
    }
}