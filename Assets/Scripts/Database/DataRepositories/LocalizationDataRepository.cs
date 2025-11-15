using Database.Data.Monsters;
using Database.Data.Systems;
using SQLite4Unity3d;

namespace Database.DataRepositories
{
    public class LocalizationDataRepository : AbstractDataRepository<string, LocalizationData>
    {
        public override void LoadData(SQLiteConnection connection, DataRegistry registry)
        {
            var list1 = connection.Table<LocalizationData>();
            foreach (var locale in list1)
            {
                this[locale.StringKey] = locale;
            }
        }
    }
}