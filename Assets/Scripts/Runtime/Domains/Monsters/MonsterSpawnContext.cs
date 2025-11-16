using UnityEngine;

namespace Runtime.Domains.Monsters
{
    public struct MonsterSpawnContext
    {
        public MonsterMovementType MovementType;
        public Vector2 SpawnPosition;
        public Transform Target;
        public float HpRate;
        public float PowerRate;
        public float SpeedRate;
        public float ScaleRate;
    }
}