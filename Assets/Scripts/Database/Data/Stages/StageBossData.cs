using SQLite4Unity3d;
using UnityEngine;

namespace Database.Data.Stages
{
    [Table("STAGE_BOSS")]
    public class StageBossData
    {
        [field: SerializeField] [Column("STAGE_ID")] public string StageID { get; private set; }
        [field: SerializeField] [Column("ELAPSED_TIME")] public int ElapsedTime { get; private set; }
        [field: SerializeField] [Column("MONSTER_ID")] public string MonsterID { get; private set; }
        [field: SerializeField] [Column("DROP_TYPE")] public DropType DropType { get; private set; }
        [field: SerializeField] [Column("HP_RATE")] public float HpRate { get; private set; }
        [field: SerializeField] [Column("POWER_RATE")] public float PowerRate { get; private set; }
        [field: SerializeField] [Column("SPEED_RATE")] public float SpeedRate { get; private set; }
    }
}