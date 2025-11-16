using Database;
using Database.Data.Stages;
using Runtime.Domains.Monsters;
using Sirenix.OdinInspector;
using UnityEngine;
using EventType = Database.Data.Stages.EventType;

namespace Runtime.Domains.Stages
{
    public class StageBehaviour : SerializedMonoBehaviour
    {
        [field: SerializeField] private StageEntity _entity;
        [field: SerializeField] private Transform[] _spawnPositions;
        [field: SerializeField] private Transform _targetTransform;
        [field: SerializeField] private MonsterFactory _monsterFactory;

        [Button]
        public void SetStage(string stageID)
        {
            if (!DataRegistry.Stages.TryGetValue(stageID, out var data))
            {
                return;
            }
            
            Initialize(data);
        }

        [Button]
        public void SetElapsedTime(float elapsedTime)
        {
            _entity.ElapsedTime = elapsedTime;
        }

        public void Initialize(StageData data)
        {
            _entity.Data = data;
            _entity.ElapsedTime = 0;

            foreach (var waveList in data.Waves.Values)
            {
                foreach (var wave in waveList)
                {
                    _entity.WaveSpawnTimers[wave] = 0;
                }
            }

            foreach (var event1 in data.Events.Values)
            {
                _entity.EventSpawnTimers[event1] = 0;
            }

            foreach (var boss in data.Bosses.Values)
            {
                _entity.BossSpawnFlags[boss] = false;
            }
        }

        private void Update()
        {
            if (_entity.Data == null) return;

            _entity.ElapsedTime += Time.deltaTime;
            int minute = Mathf.FloorToInt(_entity.ElapsedTime / 60);

            HandleWaves(minute);
            HandleEvents(minute);
            HandleBosses(minute);
        }

        private void HandleWaves(int minute)
        {
            if (!_entity.Data.Waves.TryGetValue(minute, out var waves))
            {
                return;
            }

            foreach (var wave in waves)
            {
                _entity.WaveSpawnTimers[wave] -= Time.deltaTime;
                if (_entity.WaveSpawnTimers[wave] <= 0)
                {
                    SpawnWave(wave);
                    _entity.WaveSpawnTimers[wave] += wave.SpawnInterval;
                }
            }
        }

        private void SpawnWave(StageWaveData wave)
        {
            var data = DataRegistry.MonsterEntities[wave.MonsterID];
            var context = new MonsterSpawnContext
            {
                MovementType = MonsterMovementType.Normal,
                SpawnPosition = _spawnPositions[Random.Range(0, _spawnPositions.Length)].position,
                Target = _targetTransform,
                HpRate = 1f,
                PowerRate = 1f,
                SpeedRate = 1f,
                ScaleRate = 1f
            };
            
            _monsterFactory.SpawnMonster(data, context);
        }

        private void HandleEvents(int minute)
        {
            if (!_entity.Data.Events.TryGetValue(minute, out var event1))
            {
                return;
            }
            
            _entity.EventSpawnTimers[event1] -= Time.deltaTime;
            if (_entity.EventSpawnTimers[event1]  <= 0)
            {
                switch (event1.EventType)
                {
                    case EventType.Rush:
                        SpawnRushEvent(event1);
                        break;
                    case EventType.Circle:
                        SpawnCircleEvent(event1);
                        break;
                }
                _entity.EventSpawnTimers[event1] += event1.EventInterval;
            }
        }
        
        private void SpawnRushEvent(StageEventData event1)
        {
            var data = DataRegistry.MonsterEntities[event1.MonsterID];
            var context = new MonsterSpawnContext
            {
                MovementType = MonsterMovementType.Rush,
                SpawnPosition = _spawnPositions[Random.Range(0, _spawnPositions.Length)].position,
                Target = _targetTransform,
                HpRate = 1f,
                PowerRate = 1f,
                SpeedRate = 2f,
                ScaleRate = 1f
            };

            for (int i = 0; i < event1.MonsterCount; i++)
            {
                _monsterFactory.SpawnMonster(data, context);
            }
        }
        
        private void SpawnCircleEvent(StageEventData event1)
        {
            var data = DataRegistry.MonsterEntities[event1.MonsterID];
            for (int i = 0; i < event1.MonsterCount; i++)
            {
                var context = new MonsterSpawnContext
                {
                    MovementType = MonsterMovementType.Normal,
                    SpawnPosition = _spawnPositions[i % _spawnPositions.Length].position,
                    Target = _targetTransform,
                    HpRate = 1f,
                    PowerRate = 1f,
                    SpeedRate = 1f,
                    ScaleRate = 1f
                };

                _monsterFactory.SpawnMonster(data, context);
            }
        }
        
        private void HandleBosses(int minute)
        {
            if (!_entity.Data.Bosses.TryGetValue(minute, out var boss))
            {
                return;
            }

            if (!_entity.BossSpawnFlags[boss])
            {
                SpawnBoss(boss);
                _entity.BossSpawnFlags[boss] = true;
            }
        }

        private void SpawnBoss(StageBossData boss)
        {
            var data = DataRegistry.MonsterEntities[boss.MonsterID];
            var context = new MonsterSpawnContext
            {
                MovementType = MonsterMovementType.Normal,
                SpawnPosition = _spawnPositions[Random.Range(0, _spawnPositions.Length)].position,
                Target = _targetTransform,
                HpRate = boss.HpRate / 100,
                PowerRate = boss.PowerRate / 100,
                SpeedRate = boss.SpeedRate / 100,
                ScaleRate = boss.ScaleRate / 100
            };
            
            _monsterFactory.SpawnMonster(data, context);
        }
    }
}