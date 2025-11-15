using SQLite4Unity3d;
using UnityEngine;

namespace Database.Data.Monsters
{
    [Table("MONSTER_BASE")]
    public class MonsterBaseData
    {
        [field: SerializeField] [Column("MONSTER_ID")] public string MonsterID { get; private set; }
        [field: SerializeField] [Column("NAME_KEY")] public string NameKey { get; private set; }
        [field: SerializeField] [Column("DESC_KEY")] public string DescKey { get; private set; }
        [field: SerializeField] [Column("RES_KEY")] public string ResKey { get; private set; }
    }
}