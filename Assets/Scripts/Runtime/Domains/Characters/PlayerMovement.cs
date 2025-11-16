using System;
using UnityEngine;

namespace Runtime.Domains.Characters
{
    public class PlayerMovement : MonoBehaviour
    {
        [field: SerializeField] private Rigidbody2D _rigidbody;
        [field: SerializeField] private float _speed;
        public Vector2 Direction { get; set; }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + Direction.normalized * _speed * Time.fixedDeltaTime);
            _rigidbody.linearVelocity = Vector2.zero;
        }
    }
}