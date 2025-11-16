using UnityEngine;

namespace Runtime.Domains.Monsters.FSM
{
    /// <summary>
    /// 몬스터 넉백 상태 구현 클래스입니다. 
    /// </summary>
    public class KnockBackState : MonsterState
    {
        private float _elapsedTime;
        
        protected override void OnEnter()
        {
            base.OnEnter();
            _elapsedTime = 0;
            Vector2 direction = _fsmBehaviour.Owner.transform.position - _fsmBehaviour.Target.position;
            _fsmBehaviour.Owner.Rigidbody.AddForce(direction.normalized * _fsmBehaviour.PendingKnockBack, ForceMode2D.Impulse);
            _fsmBehaviour.PendingKnockBack = 0;
        }

        protected override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            _elapsedTime += Time.fixedDeltaTime;
            if (_elapsedTime >= _fsmBehaviour.Owner.Entity.KnockBackTime)
            {
                _fsmBehaviour.ChangeDefaultState();
            }
        }
    }
}