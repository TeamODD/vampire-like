using System;
using Database.Data.Monsters;
using Runtime.Domains.Monsters;
using UnityEngine;

namespace Runtime.Domains.Stages
{
    [Serializable]
    public class MonsterFactory
    {
        [field: SerializeField] private MonsterBehaviour _monsterPrefab;
        
        public MonsterBehaviour SpawnMonster(MonsterEntityData data, MonsterSpawnContext context)
        {
            var behaviour = UnityEngine.Object.Instantiate(_monsterPrefab);
            behaviour.Initialize(data, context);
            return behaviour;
        }
    }
}