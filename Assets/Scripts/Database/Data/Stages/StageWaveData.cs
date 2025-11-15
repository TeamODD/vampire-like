using SQLite4Unity3d;
using UnityEngine;

namespace Database.Data.Stages
{
    [Table("STAGE_WAVE")]
    public class StageWaveData
    {
        [field: SerializeField] [Column("STAGE_ID")] public string StageID { get; private set; }
        [field: SerializeField] [Column("ELAPSED_TIME")] public int ElapsedTime { get; private set; }
        [field: SerializeField] [Column("MONSTER_ID")] public string MonsterID { get; private set; }
        [field: SerializeField] [Column("SPAWN_INTERVAL")] public float SpawnInterval { get; private set; }
        [field: SerializeField] [Column("EXP_TIER")] public ExpType ExpTier { get; private set; }
    }
}