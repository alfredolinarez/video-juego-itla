using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class InLoadingState : State<GameManager>
    {
        public override void EnterState(GameManager entity)
        {
            entity.ShowFade(true);
        }

        public override void ExitState(GameManager entity)
        {
            entity.ShowFade(false);
        }

        public override void TickState(GameManager entity) {
            base.TickState(entity);
            Debug.Log("InLoading");
        }
  }
}