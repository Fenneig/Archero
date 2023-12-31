﻿using Archero.Character.Player;
using UnityEngine;

namespace Archero.Components
{
    public class GoldCoin : MonoBehaviour, ICollectable
    {
        [SerializeField] private int _amount;

        private Transform _cachedTransform;
        
        public void Setup(int amount)
        {
            _amount = amount;
        }

        private void Awake()
        {
            _cachedTransform = transform;
            _cachedTransform.position -= new Vector3(0, _cachedTransform.position.y - 1f, 0);
        }

        private void Update()
        {
            _cachedTransform.Rotate(Vector3.forward, 1f);
        }

        public void Collect(Inventory inventory)
        {
            inventory.AddToInventory(_amount);
            Destroy(gameObject);
        }
    }
}