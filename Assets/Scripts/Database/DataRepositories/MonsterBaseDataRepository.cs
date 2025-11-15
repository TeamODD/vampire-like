using Database.Data.Items;
using SQLite4Unity3d;

namespace Database.DataRepositories
{
    public class MonsterBaseDataRepository : AbstractDataRepository<string, MonsterBaseData>
    {
        public override void LoadData(SQLiteConnection connection, DataRegistry registry)
        {
            var list1 = connection.Table<MonsterBaseData>();
            foreach (var monster in list1)
            {
                this[monster.MonsterID] = monster;
            }
        }
    }
}