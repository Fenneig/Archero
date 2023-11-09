using UnityEngine;

namespace Archero.Character.Enemy.States
{
    public abstract class BehaviourState : ScriptableObject
    {
        public EnemyUnit StateOwner { set; get; }
        public bool IsFinished { get; protected set; }
        public virtual void Init(){}
        public abstract void OnUpdate();
        public void EarlyComplete() => IsFinished = true;
    }
}