using Database.Data.Stages;
using SQLite4Unity3d;

namespace Database.DataRepositories
{
    public class StageDataRepository : AbstractDataRepository<string, StageData>
    {
        public override void LoadData(SQLiteConnection connection, DataRegistry registry)
        {
            var list1 = connection.Table<StageData>();
            foreach (var stage in list1)
            {
                this[stage.StageID] = stage;
            }
            
            var list2 = connection.Table<StageWaveData>();
            foreach (var wave in list2)
            {
                if (!this[wave.StageID].Waves.TryGetValue(wave.ElapsedTime, out var waves))
                {
                    this[wave.StageID].Waves[wave.ElapsedTime] = new();
                }
                this[wave.StageID].Waves[wave.ElapsedTime].Add(wave);
            }
            
            var list3 = connection.Table<StageEventData>();
            foreach (var event1 in list3)
            {
                this[event1.StageID].Events[event1.ElapsedTime] = event1;
            }
            
            var list4 = connection.Table<StageBossData>();
            foreach (var boss in list4)
            {
                this[boss.StageID].Bosses[boss.ElapsedTime] = boss;
            }
        }
    }
}