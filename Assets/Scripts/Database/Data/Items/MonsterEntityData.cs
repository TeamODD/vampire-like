using SQLite4Unity3d;
using UnityEngine;

namespace Database.Data.Items
{
    [Table("MONSTER_Entity")]
    public class MonsterEntityData
    {
        [field: SerializeField] [Column("ENTITY_ID")] public string EntityID { get; private set; }
        [field: SerializeField] [Column("MONSTER_ID")] public string MonsterID { get; private set; }
        [field: SerializeField] [Column("RES_KEY")] public string ResKey { get; private set; }
        [field: SerializeField] [Column("HP")] public float Hp { get; private set; }
        [field: SerializeField] [Column("POWER")] public float Power { get; private set; }
        [field: SerializeField] [Column("SPEED")] public float Speed { get; private set; }
    }
}