using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponNames
{
    Pistol,
    PlasmaRifle,
    Rifle1,
    Rifle2,
    Rifle3,
    Rifle4,
    Rifle5,
    Shotgun,
    RocketLauncher,
    MachineGun,
    Knife,
    Sniper
}

public class PlayerInventory : MonoBehaviour
{
    public string[] weapons = { "", "", "", "", "", "", "", "", "", "", "", "" };
    public Sprite[] weaponImages = new Sprite[13];
}
