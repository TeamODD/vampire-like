using System;
using System.Collections.Generic;
using Runtime.Domains.Items;
using UnityEngine;

namespace Runtime.Domains.Characters
{
    [Serializable]
    public class CharacterEntity
    {
        public string DefaultWeaponID;
        public int MaxWeaponCount = 6;
        public List<WeaponEntity> Weapons = new();
        public Vector2 Direction = Vector2.right;
    }
}