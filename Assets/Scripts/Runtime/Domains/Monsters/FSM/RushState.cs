using UnityEngine;

namespace Runtime.Domains.Monsters.FSM
{
    /// <summary>
    /// 돌진형 몬스터의 이동 구현 클래스입니다. 생성 시점 플레이어의 방향을 돌진 방향으로 설정하여 돌진합니다. 
    /// </summary>
    public class RushState : MonsterState
    {
        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        
        public override void Initialize(MonsterFSMBehaviour fsmBehaviour)
        {
            base.Initialize(fsmBehaviour);
            _rigidbody = _fsmBehaviour.Owner.Rigidbody;
            _direction = _fsmBehaviour.Target.position - _fsmBehaviour.Owner.transform.position;
        }

        protected override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            _rigidbody.MovePosition(_rigidbody.position + _direction.normalized * _fsmBehaviour.Owner.Entity.Speed * Time.fixedDeltaTime);
            _rigidbody.linearVelocity = Vector2.zero;
        }
    }
}