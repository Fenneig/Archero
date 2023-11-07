using Archero.Character.Components;
using UnityEngine;

namespace Archero.Character
{
    [RequireComponent(typeof(MovementComponent))]
    public class Unit : MonoBehaviour
    {
        public Transform CachedTransform { get; private set; }
        
        protected virtual void Awake()
        {
            CachedTransform = transform;
        }
    }
}