using System.Collections.Generic;
using Runtime.Domains.Common.FSM;
using Runtime.Domains.Common.Hits;
using UnityEngine;

namespace Runtime.Domains.Monsters.FSM
{
    public class MonsterFSMBehaviour : FSMBehaviour, IHittable
    {
        [field: SerializeField] private Dictionary<MonsterFSMType, MonsterState> _states = new();
        [HideInInspector] public int PendingKnockBack;
        public MonsterBehaviour Owner { get; private set; }
        public Transform Target { get; private set; }

        public void Initialize(MonsterBehaviour onwer, Transform target)
        {
            Owner = onwer;
            _defaultState = onwer.Entity.MovementType == MonsterMovementType.Rush
                ? _states[MonsterFSMType.Rush]
                : _states[MonsterFSMType.Normal];
            
            Target = target;
                
            foreach (var state in _states.Values)
            {
                state.Initialize(this);
            }
            
            ChangeDefaultState();
        }
        
        public void Hit(ref HitContext context)
        {
            if (Owner.Entity.Hp <= 0)
            {
                ChangeState(_states[MonsterFSMType.Dead]);
                return;
            }

            if (context.Knockback > 0)
            {
                PendingKnockBack = context.Knockback;
                ChangeState(_states[MonsterFSMType.KnockBack]);
                return;
            }

            switch (Owner.Entity.MovementType)
            {
                case MonsterMovementType.Normal:
                    ChangeState(_states[MonsterFSMType.Normal]);
                    break;
                case MonsterMovementType.Rush:
                    ChangeState(_states[MonsterFSMType.Rush]);
                    break;
                default:
                    return;
            }
        }
    }
}