using SQLite4Unity3d;
using UnityEngine;

namespace Database.Data.Stages
{
    [Table("STAGE_EVENT")]
    public class StageEventData
    {
        [field: SerializeField] [Column("STAGE_ID")] public string StageID { get; private set; }
        [field: SerializeField] [Column("ELAPSED_TIME")] public int ElapsedTime { get; private set; }
        [field: SerializeField] [Column("EVENT_TYPE")] public EventType EventType { get; private set; }
        [field: SerializeField] [Column("EVENT_INTERVAL")] public float EventInterval { get; private set; }
        [field: SerializeField] [Column("MONSTER_ID")] public string MonsterID { get; private set; }
        [field: SerializeField] [Column("EXP_TIER")] public ExpType ExpType { get; private set; }
    }
}