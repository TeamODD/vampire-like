using Runtime.Domains.Characters;

namespace Runtime.Domains.Items
{
    public interface IWeaponStrategy
    {
        void Use(CharacterBehaviour owner, WeaponEntity entity);
    }
}