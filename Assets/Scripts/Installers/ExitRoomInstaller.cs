using Archero.Systems;
using UnityEngine;
using Zenject;

namespace Archero.Installers
{
    public class ExitRoomInstaller : MonoInstaller
    {
        [SerializeField] private ExitRoom _exitRoom;
        public override void InstallBindings()
        {
            Container
                .Bind<ExitRoom>()
                .FromInstance(_exitRoom)
                .AsSingle();
        }
    }
}