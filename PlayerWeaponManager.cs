using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public Transform weaponHolder_1;
    public Transform weaponHolder_2;
    public Transform weaponHolder_3;
    public GameObject[] weaponPrefabs; // Array of weapon prefabs.

    void Start()
    {
        EquipWeapons();
    }

    void EquipWeapons()
    {
        int equippedWeaponIndex_1 = PlayerPrefs.GetInt("EquippedWeaponIndex_1", -1);
        int equippedWeaponIndex_2 = PlayerPrefs.GetInt("EquippedWeaponIndex_2", -1);
        int equippedWeaponIndex_3 = PlayerPrefs.GetInt("EquippedWeaponIndex_3", -1);

        if (equippedWeaponIndex_1 >= 0)
            InstantiateWeapon_1(equippedWeaponIndex_1);
        if (equippedWeaponIndex_2 >= 0)
            InstantiateWeapon_2(equippedWeaponIndex_2);
        if (equippedWeaponIndex_3 >= 0)
            InstantiateWeapon_3(equippedWeaponIndex_3);
    }

    void InstantiateWeapon_1(int weaponIndex)
    {
        if (weaponIndex < weaponPrefabs.Length)
        {
            GameObject weapon = Instantiate(weaponPrefabs[weaponIndex], weaponHolder_1);
        }
    }
    void InstantiateWeapon_2(int weaponIndex)
    {
        if (weaponIndex < weaponPrefabs.Length)
        {
            GameObject weapon = Instantiate(weaponPrefabs[weaponIndex], weaponHolder_2);
        }
    }
    void InstantiateWeapon_3(int weaponIndex)
    {
        if (weaponIndex < weaponPrefabs.Length)
        {
            GameObject weapon = Instantiate(weaponPrefabs[weaponIndex], weaponHolder_3);
        }
    }
}
