using System;
using Database.Data.Monsters;
using UnityEngine;

namespace Runtime.Domains.Monsters
{
    [Serializable]
    public class MonsterEntity
    {
        public const float HitCooldown = 0.5f;
        [field: SerializeField] public float Hp;
        [field: SerializeField] public float Power;
        [field: SerializeField] public float Speed;
        [field: SerializeField] public MonsterMovementType MovementType;
        [field: SerializeField] public float HitElapsedTime;
        [field: SerializeField] public float KnockBackTime = 0.5f;

        public MonsterEntity(MonsterEntityData entityData, in MonsterSpawnContext spawnContext)
        {
            Hp = entityData.Hp;
            Power = entityData.Power;
            Speed = entityData.Speed / 100 * 2;
            MovementType = spawnContext.MovementType;
        }
    }
}