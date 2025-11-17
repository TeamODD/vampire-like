using System;
using Runtime.Domains.Characters;
using Runtime.Domains.Common.Hits;
using Runtime.Domains.Monsters;
using UnityEngine;

namespace Runtime.Domains.Items.Behaviours
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class KnifeProjectileBehaviour : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private int _damage;
        private int _knockBack;
        private float _speed;
        private int _pierce;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + _direction * _speed * Time.fixedDeltaTime);
            _rigidbody.linearVelocity = Vector2.zero;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Monster"))
            {
                if(other.TryGetComponent<MonsterBehaviour>(out var monster))
                {
                    HitContext context = new HitContext()
                    {
                        Damage = _damage,
                        Knockback = _knockBack,
                    };
                    monster.Hit(ref context);

                    if (--_pierce <= 0)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }

        public void Initialize(CharacterBehaviour owner, WeaponEntity entity)
        {
            transform.localScale *= entity.CurrentStat.Area / 100;
            _knockBack = entity.Data.KnockBack;
            _direction = owner.Entity.Direction;
            _damage = entity.CurrentStat.Power;
            _speed = entity.CurrentStat.Speed / 100 * 4;
            _pierce = entity.CurrentStat.Pierce;
            
            // 회전 처리
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}