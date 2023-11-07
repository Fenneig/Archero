﻿using UnityEngine;
using UnityEngine.AI;

namespace Archero.Character.Components
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        protected NavMeshAgent NavMeshAgent => _navMeshAgent;
        protected Transform CachedTransform; 
        //Modifier that makes navmesh feels "smooth"
        private const float ACCELERATION_MODIFIER = 2f;

        private void Awake()
        {
            CachedTransform = transform;
        }

        public void Setup(float speed)
        {
            _navMeshAgent.speed = speed;
            _navMeshAgent.acceleration = speed * ACCELERATION_MODIFIER;
        }

    }
}