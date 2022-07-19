using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public WeaponNames weaponName;
    public int ammoInCharger;
    public int rechargeAmmo;
    public float damage;
    public float range;
    public float fireRate;
    public float impactForce;

    public Weapon(
        WeaponNames _weaponName, 
        int _ammoInCharger, 
        int _rechargeAmmo, 
        float _damage, 
        float _range, 
        float _fireRate, 
        float _impactForce
        )
    {
        weaponName = _weaponName;
        ammoInCharger = _ammoInCharger;
        rechargeAmmo = _rechargeAmmo;
        damage = _damage;
        range = _range;
        fireRate = _fireRate;
        impactForce = _impactForce;
    }
}
