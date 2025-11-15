using SQLite4Unity3d;
using UnityEngine;

namespace Database.Data.Items
{
    [Table("ITEM_ACCESSORY_LEVEL")]
    public class AccessoryStatData
    {
        [field: SerializeField] [Column("ITEM_ID")] public string ItemID { get; private set; }
        [field: SerializeField] [Column("LEVEL")] public int Level { get; private set; }
        [field: SerializeField] [Column("ADD_POWER")] public int Power { get; private set; }
        [field: SerializeField] [Column("ADD_AREA")] public float Area { get; private set; }
        [field: SerializeField] [Column("ADD_AMOUNT")] public int Amount { get; private set; }
        [field: SerializeField] [Column("ADD_SPEED")] public float Speed { get; private set; }
        [field: SerializeField] [Column("ADD_DURATION")] public float Duration { get; private set; }
        [field: SerializeField] [Column("ADD_COOLDOWN")] public float Cooldown { get; private set; }
    }
}