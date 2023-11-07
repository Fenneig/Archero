using Archero.Player;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace Archero.Camera
{
    public class SetFollowComponent : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera;

        [Inject]
        public void Construct(PlayerUnit player)
        {
            _camera.Follow = player.transform;
            _camera.LookAt = player.transform;
        }
    }
}