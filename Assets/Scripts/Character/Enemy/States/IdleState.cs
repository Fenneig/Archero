using UnityEngine;

namespace Archero.Character.Enemy.States
{
    [CreateAssetMenu(menuName = "EnemyStates/Idle State", fileName = "Idle")]
    public class IdleState : BehaviourState
    {
        public override void OnUpdate()
        {
            if (StateOwner.AttackCooldown.IsReady) 
                IsFinished = true;
        }
    }
}