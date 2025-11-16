using System;
using Database.Data.Items;

namespace Runtime.Domains.Items
{
    [Serializable]
    public class WeaponEntity
    {
        public WeaponData Data;
        public WeaponStatData CurrentStat;
        public int Level;
        public float ElapsedTime;

        public WeaponEntity(WeaponData data)
        {
            Data = data;
            Level = 1;
            ElapsedTime = 0;
            CurrentStat = data.Stats[1];
        }
    }
}