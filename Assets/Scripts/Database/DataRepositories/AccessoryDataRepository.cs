using Database.Data.Items;
using SQLite4Unity3d;

namespace Database.DataRepositories
{
    public class AccessoryDataRepository : AbstractDataRepository<string, AccessoryData>
    {
        public override void LoadData(SQLiteConnection connection, DataRegistry registry)
        {
            var list1 = connection.Table<AccessoryData>();
            foreach (var accessory in list1)
            {
                this[accessory.ItemID] = accessory;
            }
            
            var list2 = connection.Table<AccessoryStatData>();
            foreach (var stat in list2)
            {
                this[stat.ItemID].Stats.Add(stat.Level, stat);
            }
        }
    }
}