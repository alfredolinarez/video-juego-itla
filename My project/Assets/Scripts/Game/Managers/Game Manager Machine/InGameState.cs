using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class InGameState : State<GameManager>
    {
        public override void EnterState(GameManager entity)
        {
            
        }

        public override void ExitState(GameManager entity)
        {
            
        }

        public override void TickState(GameManager entity)
        {
            Debug.Log("InGame");
            if (Input.GetButtonDown("Pause") && entity.CanPause)
            {
                entity.GameManagerMachine.SetState(entity.InPauseState);
            }
        }
    }
}