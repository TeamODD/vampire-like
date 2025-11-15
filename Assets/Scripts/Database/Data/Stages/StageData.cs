using System.Collections.Generic;
using SQLite4Unity3d;
using UnityEngine;

namespace Database.Data.Stages
{
    [Table("STAGE_BASE")]
    public class StageData
    {
        [field: SerializeField] [Column("STAGE_ID")] public string StageID { get; private set; }
        [field: SerializeField] [Column("NAME_KEY")] public string NameKey { get; private set; }
        [field: SerializeField] [Column("DESC_KEY")] public string DescKey { get; private set; }
        [field: SerializeField] [Column("RES_KEY")] public string ResKey { get; private set; }
        [field: SerializeField] public Dictionary<int, List<StageWaveData>> Waves { get; private set; } = new();
        [field: SerializeField] public Dictionary<int, StageEventData> Events { get; private set; } = new();
        [field: SerializeField] public Dictionary<int, StageBossData> Bosses { get; private set; } = new();
    }
}