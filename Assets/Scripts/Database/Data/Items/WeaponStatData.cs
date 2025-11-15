using SQLite4Unity3d;
using UnityEngine;

namespace Database.Data.Items
{
    [Table("VIEW_ITEM_WEAPON_STAT")]
    public class WeaponStatData
    {
        [field: SerializeField] [Column("ITEM_ID")] public string ItemID { get; private set; }
        [field: SerializeField] [Column("LEVEL")] public int Level { get; private set; }
        [field: SerializeField] [Column("POWER")] public int Power { get; private set; }
        [field: SerializeField] [Column("AREA")] public float Area { get; private set; }
        [field: SerializeField] [Column("AMOUNT")] public int Amount { get; private set; }
        [field: SerializeField] [Column("SPEED")] public float Speed { get; private set; }
        [field: SerializeField] [Column("DURATION")] public float Duration { get; private set; }
        [field: SerializeField] [Column("COOLDOWN")] public float Cooldown { get; private set; }
        [field: SerializeField] [Column("PIERCE")] public int Pierce { get; private set; }
    }
}