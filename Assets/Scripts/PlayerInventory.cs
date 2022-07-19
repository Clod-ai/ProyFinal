using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    Sniper,
    None
}

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    public int selectedWeapon = 0;

    public Image weaponInGameUI;

    public GameObject[] weaponsPrefabs;
    public Sprite[] weaponsSprites;
    public List<Weapon> weaponsInInventory = new List<Weapon>();

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddWeapon(Weapon newWeapon)
    {
        if (weaponsInInventory.Count > 0)
        {
            for (int i = 0; i < weaponsInInventory.Count; i++)
            {
                if (newWeapon.weaponName == weaponsInInventory[i].weaponName)
                {
                    weaponsInInventory[i].rechargeAmmo += newWeapon.ammoInCharger;
                    break;
                }
            }
            weaponsInInventory.Add(newWeapon);
        }
        else
        {
            weaponsInInventory.Add(newWeapon);
            ChangeWeapon(selectedWeapon, (int) newWeapon.weaponName);
            selectedWeapon = (int) newWeapon.weaponName;
            //LanzarEvento de cambio de arma;
        }
    }

    public void ChangeWeapon(int previousWeapon, int newWeapon)
    {
        weaponsPrefabs[previousWeapon].SetActive(false);
        weaponsPrefabs[newWeapon].SetActive(true);
        weaponInGameUI.sprite = weaponsSprites[newWeapon];
    }
}
