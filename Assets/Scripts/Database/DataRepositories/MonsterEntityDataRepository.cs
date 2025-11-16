using Database.Data.Monsters;
using SQLite4Unity3d;
using UnityEngine;

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
                monster.AnimatorController = Resources.Load<RuntimeAnimatorController>($"Monsters/Animators/{monster.ResKey}");
            }
        }
    }
}