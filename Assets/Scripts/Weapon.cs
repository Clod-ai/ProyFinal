using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public WeaponNames weaponName;
    public int ammoInCharger;
    public int rechargeAmmo;

    public Weapon(WeaponNames _weaponName, int _ammoInCharger, int _rechargeAmmo)
    {
        weaponName = _weaponName;
        ammoInCharger = _ammoInCharger;
        rechargeAmmo = _rechargeAmmo;
    }
}
