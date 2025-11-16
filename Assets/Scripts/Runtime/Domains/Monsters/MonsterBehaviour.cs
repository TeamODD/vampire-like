using System;
using Database.Data.Monsters;
using Runtime.Domains.Common.Hits;
using Runtime.Domains.Monsters.FSM;
using UnityEngine;

namespace Runtime.Domains.Monsters
{
    /// <summary>
    /// 몬스터의 책임을 담당하는 컴포넌트 클래스입니다. Facade 패턴으로 구현하여, 외부에서 필요한 로직을 이 클래스에서 구현하여 드러냅니다.
    /// </summary>
    [RequireComponent(typeof(MonsterFSMBehaviour))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class MonsterBehaviour : MonoBehaviour, IHittable
    {
        private MonsterFSMBehaviour _fsm;
        [field: SerializeField] public MonsterEntity Entity { get; private set; }
        public Animator Animator { get; private set; }
        public Rigidbody2D Rigidbody { get; private set; }
        public SpriteRenderer SpriteRenderer { get; private set; }

        private void Awake()
        {
            _fsm = GetComponent<MonsterFSMBehaviour>();
            Animator = GetComponent<Animator>();
            Rigidbody = GetComponent<Rigidbody2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (Entity == null)
            {
                return;
            }
            
            Entity.HitElapsedTime -= Time.deltaTime;
            Entity.HitElapsedTime = Mathf.Max(0f, Entity.HitElapsedTime);
        }
        
        private void OnCollisionStay2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                return;
            }
            
            if (Entity.HitElapsedTime <= 0)
            {
                // TODO: Hit Player
                Entity.HitElapsedTime += MonsterEntity.HitCooldown;
            }
        }
        
        public void Initialize(MonsterEntityData entityData, in MonsterSpawnContext spawnContext)
        {
            Entity = new(entityData, spawnContext);
            if(entityData.AnimatorController != null)
            {
                Animator.runtimeAnimatorController = entityData.AnimatorController;
            }
            transform.position = spawnContext.SpawnPosition;
            _fsm.Initialize(this, spawnContext.Target);
            gameObject.SetActive(true);
        }
        
        public void Hit(ref HitContext context)
        {
            Entity.Hp -= Mathf.Max(0, context.Damage);
            _fsm.Hit(ref context);
        }
    }
}
