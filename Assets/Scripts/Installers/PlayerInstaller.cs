using Archero.Character.Player;
using UnityEngine;
using Zenject;

namespace Archero.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerUnit _playerUnitPrefab;
        [SerializeField] private Transform _playerSpawnPosition;

        [Inject] private DiContainer _diContainer;

        public override void InstallBindings()
        {
            var player = _diContainer.InstantiatePrefabForComponent<PlayerUnit>(
                _playerUnitPrefab, _playerSpawnPosition.position, Quaternion.identity, null);

            _diContainer.Bind<PlayerUnit>()
                .FromInstance(player)
                .AsSingle()
                .NonLazy();

            _diContainer.QueueForInject(player);
        }
    }
}