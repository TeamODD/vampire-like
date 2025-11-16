using System;
using System.Collections.Generic;
using Database.Data.Stages;

namespace Runtime.Domains.Stages
{
    [Serializable]
    public class StageEntity
    {
        public StageData Data;
        public float ElapsedTime; // 전체 진행 시간(초)
    
        // 스폰을 위한 런타임 타이머
        public Dictionary<StageWaveData, float> WaveSpawnTimers = new();
        public Dictionary<StageEventData, float> EventSpawnTimers = new();
        public Dictionary<StageBossData, bool> BossSpawnFlags = new();
    }
}