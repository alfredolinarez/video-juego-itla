using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class InMenuState : State<GameManager>
    {
        public override void TickState(GameManager entity) {
            base.TickState(entity);
            Debug.Log("InMenu");
        }
    }
}