using UnityEngine;

namespace Archero.Character.Enemy.States
{
    [CreateAssetMenu(menuName = "EnemyStates/Idle State", fileName = "Idle")]
    public class IdleState : BehaviourState
    {
        public override void Init()
        {
            StateOwner.IdleTimer.Reset();
        }

        public override void OnUpdate()
        {
            if (StateOwner.IdleTimer.IsReady) 
                IsFinished = true;
        }
    }
}