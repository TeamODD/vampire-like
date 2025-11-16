using System;
using System.Collections.Generic;
using Runtime.Domains.Items;

namespace Runtime.Domains.Characters
{
    [Serializable]
    public class CharacterEntity
    {
        public string DefaultWeaponID;
        public int MaxWeaponCount = 6;
        public List<WeaponEntity> Weapons = new();
    }
}