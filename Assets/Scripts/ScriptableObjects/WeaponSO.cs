using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponSO", menuName = "ScriptableObjects/Weapon")]
public class WeaponSO : ScriptableObject
{
    public WeaponNames weaponName;
    public int ammoInCharger;
    public int rechargeAmmo;
    public float damage;
    public float range;
    public float fireRate;
    public float impactForce;
}
