using Runtime.Domains.Characters;
using UnityEngine;

namespace Runtime.Domains.Items
{
    public abstract class WeaponStrategy : ScriptableObject, IWeaponStrategy
    {
        public virtual void Use(CharacterBehaviour owner, WeaponEntity entity)
        {
            entity.ElapsedTime -= Time.deltaTime;

            if (entity.ElapsedTime <= 0f)
            {
                Execute(owner, entity);
                entity.ElapsedTime = entity.CurrentStat.Cooldown; 
            }
        }
        
        protected abstract void Execute(CharacterBehaviour owner, WeaponEntity entity);
    }
}