using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponsData
{
    public string weaponSkin;
    public string assetPath;
    public WeaponsData(Weapon weapon)
    {
        weaponSkin = weapon.str;
        assetPath = weapon.assetPath;
    }
}
