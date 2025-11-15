using Database.Data.Items;
using SQLite4Unity3d;

namespace Database.DataRepositories
{
    public class ItemEvolutionDataRepository : AbstractDataRepository<string, ItemEvolutionData>
    {
        public override void LoadData(SQLiteConnection connection, DataRegistry registry)
        {
            var list1 = connection.Table<ItemEvolutionData>();
            foreach (var evolution in list1)
            {
                this[evolution.ItemID] = evolution;
            }
        }
    }
}