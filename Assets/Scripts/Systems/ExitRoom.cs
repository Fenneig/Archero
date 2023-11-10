using System;
using Archero.Character.Player;
using UnityEngine;
using Zenject;

namespace Archero.Systems
{
    public class ExitRoom : MonoBehaviour
    {
        [SerializeField] private Animator _doorAnimator;
        [SerializeField] private Animator _rightDoorAnimator;
        [SerializeField] private ParticleSystem _exitShowParticles;
        private static readonly int Open = Animator.StringToHash("Open");

        private Action _gameWin;
        
        [Inject]
        private void Construct(GameState gameState)
        {
            _gameWin += gameState.GameWin;
        }
        
        public void ShowExit()
        {
            _doorAnimator.SetTrigger(Open);
            _rightDoorAnimator.SetTrigger(Open);
            _exitShowParticles.Play();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerUnit>(out _))
            {
                _gameWin?.Invoke();
            }
        }
    }
}