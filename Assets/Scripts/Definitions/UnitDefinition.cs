using UnityEngine;

namespace Archero.Definitions
{
    public class UnitDefinition : ScriptableObject
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private int _hp;
        [SerializeField] private float _attackSpeed;
        [SerializeField] private int _attackDamage;
        
        public float MoveSpeed => _moveSpeed;
        public int Hp => _hp;
        public float AttackSpeed => _attackSpeed;
        public int AttackDamage => _attackDamage;
    }
}