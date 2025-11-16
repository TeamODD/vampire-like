using Runtime.Domains.Characters;
using UnityEngine;

namespace Runtime.Domains.Items.Strategies
{
    [CreateAssetMenu(menuName = "Weapons/Knife")]
    public class KnifeStrategy : WeaponStrategy
    {
        protected override void Execute(CharacterBehaviour owner, WeaponEntity entity)
        {
            // TODO: 투사체 발사
            Debug.Log("Used Knife");
        }
    }
}