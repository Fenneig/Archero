using Archero.Systems;
using UnityEngine;
using Zenject;

namespace Archero.Installers
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoader _sceneLoader;

        public override void InstallBindings()
        {
            Container
                .Bind<SceneLoader>()
                .FromInstance(_sceneLoader)
                .AsSingle();
        }
    }
}