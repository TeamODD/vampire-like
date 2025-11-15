using Database.Data.Items;
using SQLite4Unity3d;

namespace Database.DataRepositories
{
    public class WeaponDataRepository : AbstractDataRepository<string, WeaponData>
    {
        public override void LoadData(SQLiteConnection connection, DataRegistry registry)
        {
            var list1 = connection.Table<WeaponData>();
            foreach (var weapon in list1)
            {
                this[weapon.ItemID] = weapon;
            }
            
            var list2 = connection.Table<WeaponStatData>();
            foreach (var stat in list2)
            {
                this[stat.ItemID].Stats.Add(stat.Level, stat);
            }
        }
    }
}