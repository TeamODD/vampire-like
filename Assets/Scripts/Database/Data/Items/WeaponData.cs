using System.Collections.Generic;
using Runtime.Domains.Items;
using SQLite4Unity3d;
using UnityEngine;

namespace Database.Data.Items
{
    [Table("ITEM_WEAPON_BASE")]
    public class WeaponData
    {
        [field: SerializeField] [Column("ITEM_ID")] public string ItemID { get; private set; }
        [field: SerializeField] [Column("NAME_KEY")] public string NameKey { get; private set; }
        [field: SerializeField] [Column("DESC_KEY")] public string DescKey { get; private set; }
        [field: SerializeField] [Column("RES_KEY")] public string ResKey { get; private set; }
        [field: SerializeField] [Column("KNOCK_BACK")] public int KnockBack { get; private set; }
        [field: SerializeField] public Dictionary<int, WeaponStatData> Stats { get; private set; } = new();
        [field: SerializeField] public IWeaponStrategy Strategy { get; set; }
    }
}