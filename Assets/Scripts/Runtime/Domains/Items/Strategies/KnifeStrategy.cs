using Runtime.Domains.Characters;
using Runtime.Domains.Items.Behaviours;
using UnityEngine;

namespace Runtime.Domains.Items.Strategies
{
    [CreateAssetMenu(menuName = "Weapons/Knife")]
    public class KnifeStrategy : WeaponStrategy
    {
        [field: SerializeField] private KnifeProjectileBehaviour _projectilePrefab;
        protected override void Execute(CharacterBehaviour owner, WeaponEntity entity)
        {
            var projectile = Instantiate(_projectilePrefab, owner.transform.position, Quaternion.identity);
            projectile.Initialize(owner, entity);
        }
    }
}