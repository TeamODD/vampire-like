using System;
using Database;
using Runtime.Domains.Items;
using UnityEngine;

namespace Runtime.Domains.Characters
{
    public class CharacterBehaviour : MonoBehaviour
    {
        [field: SerializeField] public CharacterEntity Entity { get; private set; }
        [field: SerializeField] private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            HandleWeapons();
        }

        private void LateUpdate()
        {
            // TODO: 추후 캐릭터 FSM으로 이동
            _spriteRenderer.sortingOrder = -Mathf.FloorToInt(transform.position.y * 100);
        }

        private void Initialize()
        {
            if (DataRegistry.Weapons.TryGetValue(Entity.DefaultWeaponID, out var weapon))
            {
                Entity.Weapons.Add(new WeaponEntity(weapon));
            }
        }

        private void HandleWeapons()
        {
            foreach (var weapon in Entity.Weapons)
            {
                weapon.Data.Strategy.Use(this, weapon);
            }
        }
    }
}