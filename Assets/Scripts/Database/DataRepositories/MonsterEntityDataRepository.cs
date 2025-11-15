using Database.Data.Items;
using SQLite4Unity3d;

namespace Database.DataRepositories
{
    public class MonsterEntityDataRepository : AbstractDataRepository<string, MonsterEntityData>
    {
        public override void LoadData(SQLiteConnection connection, DataRegistry registry)
        {
            var list1 = connection.Table<MonsterEntityData>();
            foreach (var monster in list1)
            {
                this[monster.EntityID] = monster;
            }
        }
    }
}