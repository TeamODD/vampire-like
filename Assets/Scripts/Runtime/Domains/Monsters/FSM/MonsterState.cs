using Runtime.Domains.Common.FSM;
using UnityEngine;

namespace Runtime.Domains.Monsters.FSM
{
    public abstract class MonsterState : FSMState
    {
        protected MonsterFSMBehaviour _fsmBehaviour;
        
        protected override void OnEnter()
        {
            base.OnEnter();
            Vector3 position = _fsmBehaviour.Owner.transform.position;
            _fsmBehaviour.Owner.transform.position = new Vector3(position.x, position.y, position.y);
            _fsmBehaviour.Owner.SpriteRenderer.flipX = position.x < _fsmBehaviour.Target.position.x;
        }

        protected override void OnLateUpdate()
        {
            base.OnLateUpdate();
            _fsmBehaviour.Owner.SpriteRenderer.sortingOrder = -Mathf.FloorToInt(_fsmBehaviour.Owner.transform.position.y * 100);
        }

        public virtual void Initialize(MonsterFSMBehaviour fsmBehaviour)
        {
            _fsmBehaviour = fsmBehaviour;
        }
    }
}