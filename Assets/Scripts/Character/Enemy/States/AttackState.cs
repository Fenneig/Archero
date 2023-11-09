using UnityEngine;

namespace Archero.Character.Enemy.States
{
    [CreateAssetMenu(menuName = "EnemyStates/Attack State", fileName = "Attack")]
    public class AttackState : BehaviourState
    {
        public override void Init()
        {
            StateOwner.Attack();
        }

        public override void OnUpdate()
        {
            
        }
    }
}