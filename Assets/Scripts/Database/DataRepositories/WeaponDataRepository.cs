using Database.Data.Items;
using Runtime.Domains.Items;
using SQLite4Unity3d;
using UnityEngine;

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
                weapon.Strategy = Resources.Load<WeaponStrategy>($"Items/Weapons/Strategies/{weapon.ResKey}");
            }
            
            var list2 = connection.Table<WeaponStatData>();
            foreach (var stat in list2)
            {
                this[stat.ItemID].Stats.Add(stat.Level, stat);
            }
        }
    }
}