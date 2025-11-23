using System.Collections.Generic;
using Database;
using Database.Data.Monsters;
using Database.Data.Stages;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public StageData StageData;
    public float time;
    public Dictionary<StageWaveData, float> timers = new();
    public Monster MonsterPrefab;
    
    public Transform SpawnPoint;
    public Transform Target;
    
    void Start()
    {
        StageData = DataRegistry.Stages["MAD_FOREST"];
    }
    
    void Update()
    {
        time += Time.deltaTime;
        int minute = Mathf.FloorToInt(time / 60);

        List<StageWaveData> list = StageData.Waves[minute];

        foreach (StageWaveData wave in list)
        {
            timers.TryAdd(wave, 0f);
            timers[wave] -= Time.deltaTime;
            if (timers[wave] <= 0)
            {
                // 몬스터 생성
                Monster monster = Instantiate(MonsterPrefab, SpawnPoint.position, Quaternion.identity);
                monster.Initialize(DataRegistry.MonsterEntities[wave.MonsterID], Target);
                
                timers[wave] += wave.SpawnInterval;
            }
        }
    }
}
