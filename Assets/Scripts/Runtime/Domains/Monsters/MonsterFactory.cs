using Database;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Domains.Monsters
{
    public class MonsterFactory : SerializedMonoBehaviour
    {
        [field: SerializeField] private MonsterBehaviour _monsterPrefab;
        [field: SerializeField] private string _monsterID;
        [field: SerializeField] private MonsterMovementType _movementType;
        [field: SerializeField] private Transform _spawnPosition;
        [field: SerializeField] private Transform _targetObject;
        
        [Button]
        public void SpawnMonster()
        {
            var data = DataRegistry.MonsterEntities[_monsterID];
            var context = new MonsterSpawnContext()
            {
                MovementType = _movementType,
                SpawnPosition = _spawnPosition.position,
                Target = _targetObject,
            };
            
            var behaviour = Instantiate(_monsterPrefab);
            behaviour.Initialize(data, context);
        }
    }
}