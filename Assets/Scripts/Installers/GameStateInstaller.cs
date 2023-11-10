using Archero.Systems;
using UnityEngine;
using Zenject;

namespace Archero.Installers
{
    public class GameStateInstaller : MonoInstaller
    {
        [SerializeField] private GameState _gameState;
        public override void InstallBindings()
        {
            Container
                .Bind<GameState>()
                .FromInstance(_gameState)
                .AsSingle();
        }
    }
}