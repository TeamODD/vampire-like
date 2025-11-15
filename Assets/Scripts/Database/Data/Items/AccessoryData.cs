using System.Collections.Generic;
using SQLite4Unity3d;
using UnityEngine;

namespace Database.Data.Items
{
    [Table("ITEM_ACCESSORY_BASE")]
    public class AccessoryData
    {
        [field: SerializeField] [Column("ITEM_ID")] public string ItemID { get; private set; }
        [field: SerializeField] [Column("NAME_KEY")] public string NameKey { get; private set; }
        [field: SerializeField] [Column("DESC_KEY")] public string DescKey { get; private set; }
        [field: SerializeField] [Column("RES_KEY")] public string ResKey { get; private set; }
        [field: SerializeField] public Dictionary<int, AccessoryStatData> Stats { get; private set; } = new();
    }
}