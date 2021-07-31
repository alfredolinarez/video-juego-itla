using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class InWingameState : State<GameManager>
    {
        public override void EnterState(GameManager entity)
        {

            entity.WinCanvasAnimator.gameObject.SetActive(true);
        }

        public override void ExitState(GameManager entity)
        {
            entity.WinCanvasAnimator?.gameObject.SetActive(false);
        }
  
        public override void TickState(GameManager entity) {
            base.TickState(entity);
            Debug.Log("InWinGame");
        }
  }
}