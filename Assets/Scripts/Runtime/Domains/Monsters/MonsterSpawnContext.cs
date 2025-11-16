using UnityEngine;

namespace Runtime.Domains.Monsters
{
    public struct MonsterSpawnContext
    {
        public MonsterMovementType MovementType;
        public Vector2 SpawnPosition;
        public Transform Target;
    }
}