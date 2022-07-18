using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public string weaponName;
    public Sprite weaponImage;
    public int ammoInCharger;
    public int totalAmmo;

    public Weapon(string _weaponName, Sprite _weaponImage, int _ammoInCharger, int _totalAmmo)
    {
        weaponName = _weaponName;
        weaponImage = _weaponImage;
        ammoInCharger = _ammoInCharger;
        totalAmmo = _totalAmmo;
    }
}
