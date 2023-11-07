using UnityEngine;

namespace Archero.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/Player")]
    public class PlayerDefinition : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _hp;
        [SerializeField] private float _attackSpeed;
        [SerializeField] private int _attackDamage;

        public float Speed => _speed;
        public int Hp => _hp;
        public int AttackDamage => _attackDamage;
        public float AttackSpeed => _attackSpeed;
    }
}