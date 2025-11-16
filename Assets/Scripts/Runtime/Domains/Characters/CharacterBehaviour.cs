using System;
using UnityEngine;

namespace Runtime.Domains.Characters
{
    public class CharacterBehaviour : MonoBehaviour
    {
        [field: SerializeField] private SpriteRenderer _spriteRenderer;
        private void LateUpdate()
        {
            _spriteRenderer.sortingOrder = -Mathf.FloorToInt(transform.position.y * 100);
        }
    }
}