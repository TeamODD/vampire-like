using SQLite4Unity3d;
using UnityEngine;

namespace Database.Data.Items
{
    [Table("ITEM_EVOLUTION")]
    public class ItemEvolutionData
    {
        [field: SerializeField] [Column("ITEM_ID")] public string ItemID { get; private set; }
        [field: SerializeField] [Column("ITEM1_ID")] public string Item1ID { get; private set; }
        [field: SerializeField] [Column("ITEM1_LEVEL")] public int Item1Level { get; private set; }
        [field: SerializeField] [Column("ITEM1_CONSUME")] public int Item1Consume { get; private set; }
        [field: SerializeField] [Column("ITEM2_ID")] public string Item2ID { get; private set; }
        [field: SerializeField] [Column("ITEM2_LEVEL")] public int Item2Level { get; private set; }
        [field: SerializeField] [Column("ITEM2_CONSUME")] public int Item2Consume { get; private set; }
        [field: SerializeField] [Column("ITEM3_ID")] public string Item3ID { get; private set; }
        [field: SerializeField] [Column("ITEM3_LEVEL")] public int Item3Level { get; private set; }
        [field: SerializeField] [Column("ITEM3_CONSUME")] public int Item3Consume { get; private set; }
    }
}