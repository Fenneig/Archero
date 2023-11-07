using UnityEngine;

namespace Archero.Character.Enemy.States
{
    [CreateAssetMenu(menuName = "EnemyStates/Chase Player State", fileName = "Chase")]
    public class ChasePlayerState : BehaviourState
    {
        public override void OnUpdate()
        {
            if (StateOwner.IsReadyForAttack())
            {
                IsFinished = true;
                StateOwner.MovementComponent.Stop();
            }
            else
            {
                StateOwner.MovementComponent.MoveTo(StateOwner.TargetTransform.position);
            }
        }
    }
}