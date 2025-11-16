using UnityEngine;

namespace Runtime.Domains.Monsters.FSM
{
    /// <summary>
    /// 일반형 몬스터 이동 구현 클래스입니다. 활성화 돼 있을 경우, 플레이어 캐릭터 방향으로 이동합니다.
    /// </summary>
    public class NormalState : MonsterState
    {
        private Rigidbody2D _rigidbody;
        
        public override void Initialize(MonsterFSMBehaviour fsmBehaviour)
        {
            base.Initialize(fsmBehaviour);
            _rigidbody = _fsmBehaviour.Owner.Rigidbody;
        }

        protected override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            Vector2 direction = _fsmBehaviour.Target.position - _fsmBehaviour.Owner.transform.position; 
            _rigidbody.MovePosition(_rigidbody.position + direction.normalized * _fsmBehaviour.Owner.Entity.Speed * Time.fixedDeltaTime);
            _rigidbody.linearVelocity = Vector2.zero;
        }

        protected override void OnLateUpdate()
        {
            base.OnLateUpdate();
            _fsmBehaviour.Owner.SpriteRenderer.flipX = _fsmBehaviour.Owner.transform.position.x < _fsmBehaviour.Target.position.x;
        }
    }
}