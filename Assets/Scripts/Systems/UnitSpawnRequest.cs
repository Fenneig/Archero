using Archero.Character;
using UnityEngine;
using Zenject;

namespace Archero.Systems
{
    public class UnitSpawnRequest : MonoBehaviour
    {
        [SerializeField] private Unit _unitPrefab;
        [SerializeField] private bool SpawnManually;

        [Inject] private DiContainer _diContainer;

        private void OnEnable()
        {
            if (!SpawnManually)
                SpawnUnit();
        }

        public void SpawnUnit()
        {
            _diContainer.InstantiatePrefab(_unitPrefab, transform.position, Quaternion.identity, null);

            Destroy(gameObject);
        }
    }
}