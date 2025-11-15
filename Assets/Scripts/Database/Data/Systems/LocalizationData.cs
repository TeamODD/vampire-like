using SQLite4Unity3d;
using UnityEngine;

namespace Database.Data.Systems
{
    [Table("SYSTEM_LOCALIZATION")]
    public class LocalizationData
    {
        [field: SerializeField] [Column("STRING_KEY")] public string StringKey { get; private set; }
        [field: SerializeField] [Column("KO_KR")] public string Korean { get; private set; }
        [field: SerializeField] [Column("EN_US")] public string English { get; private set; }
    }
}