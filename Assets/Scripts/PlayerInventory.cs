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
    public int selectedWeaponIndex = 0;

    public GameObject[] weaponsPrefabs;
    public Sprite[] weaponsSprites;
    public List<Weapon> weaponsInInventory = new List<Weapon>();

    public Image weaponInGameUI;
    public Text weaponAmmoText;

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
            ChangeWeaponFirstTime(selectedWeapon, (int) newWeapon.weaponName);
            selectedWeapon = (int) newWeapon.weaponName;
            selectedWeaponIndex = 0;
        }
    }

    public void ChangeWeaponFirstTime(int previousWeapon, int newWeapon)
    {
        weaponsPrefabs[previousWeapon].SetActive(false);
        weaponsPrefabs[newWeapon].SetActive(true);
        weaponInGameUI.sprite = weaponsSprites[newWeapon];
        //weaponAmmoText.text = weaponsInInventory[selectedWeaponIndex].ammoInCharger + "/" + weaponsInInventory[selectedWeaponIndex].rechargeAmmo;
    }

    public void SelectPreviousWeapon()
    {
        if (weaponsInInventory.Count > 1)
        {
            if (selectedWeaponIndex == 0)
            {
                weaponsPrefabs[selectedWeapon].SetActive(false);
                selectedWeaponIndex = weaponsInInventory.Count - 1;
                selectedWeapon = (int) weaponsInInventory[selectedWeaponIndex].weaponName;
                weaponsPrefabs[selectedWeapon].SetActive(true);
                weaponInGameUI.sprite = weaponsSprites[selectedWeapon];
                //weaponAmmoText.text = weaponsInInventory[selectedWeaponIndex].ammoInCharger + "/" + weaponsInInventory[selectedWeaponIndex].rechargeAmmo;
            }
            else
            {
                weaponsPrefabs[selectedWeapon].SetActive(false);
                selectedWeaponIndex -= 1;
                selectedWeapon = (int) weaponsInInventory[selectedWeaponIndex].weaponName;
                weaponsPrefabs[selectedWeapon].SetActive(true);
                weaponInGameUI.sprite = weaponsSprites[selectedWeapon];
                //weaponAmmoText.text = weaponsInInventory[selectedWeaponIndex].ammoInCharger + "/" + weaponsInInventory[selectedWeaponIndex].rechargeAmmo;
            }
        }
    }

    public void SelectNextWeapon()
    {
        if (weaponsInInventory.Count > 1)
        {
            if (selectedWeaponIndex == weaponsInInventory.Count - 1)
            {
                weaponsPrefabs[selectedWeapon].SetActive(false);
                selectedWeaponIndex = 0;
                selectedWeapon = (int) weaponsInInventory[selectedWeaponIndex].weaponName;
                weaponsPrefabs[selectedWeapon].SetActive(true);
                weaponInGameUI.sprite = weaponsSprites[selectedWeapon];
                //weaponAmmoText.text = weaponsInInventory[selectedWeaponIndex].ammoInCharger + "/" + weaponsInInventory[selectedWeaponIndex].rechargeAmmo;
            }
            else
            {
                weaponsPrefabs[selectedWeapon].SetActive(false);
                selectedWeaponIndex += 1;
                selectedWeapon = (int)weaponsInInventory[selectedWeaponIndex].weaponName;
                weaponsPrefabs[selectedWeapon].SetActive(true);
                weaponInGameUI.sprite = weaponsSprites[selectedWeapon];
                //weaponAmmoText.text = weaponsInInventory[selectedWeaponIndex].ammoInCharger + "/" + weaponsInInventory[selectedWeaponIndex].rechargeAmmo;
            }
        }
    }
}
