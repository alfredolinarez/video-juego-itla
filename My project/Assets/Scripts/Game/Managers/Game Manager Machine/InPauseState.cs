using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class InPauseState : State<GameManager>
    {
        public override void EnterState(GameManager entity)
        {
            Time.timeScale = 0f;

            entity.PausePanel.SetActive(true);
        }

        public override void TickState(GameManager entity)
        {
            Debug.Log("InPause");

            if(Input.GetButtonDown("Pause"))
            {
                entity.GameManagerMachine.SetState(entity.InGameState);
            }
        }
        public override void ExitState(GameManager entity)
        {
            Time.timeScale = entity.InitialTimeScale;

            entity.PausePanel.SetActive(false);
        }
    }
}