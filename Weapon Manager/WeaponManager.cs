using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons;

    public GameObject EquipBtn;
    public GameObject EquippedBtn;

    bool weaponBtnChanged = false;
    bool SlotChanged = false;
    int currentWI;
    int currentSlotIdx;
    int EquippedWeaponIndex;
    public int EquippedWeaponIndex_1;
    public int EquippedWeaponIndex_2;
    public int EquippedWeaponIndex_3;

    void Start()
    {
        EquipBtn.SetActive(true);
        EquippedBtn.SetActive(false);
    }

    void Update()
    {
        if (weaponBtnChanged)
        {
            WeaponChanged();
            weaponBtnChanged = false;
        }
        if (EquippedWeaponIndex_1 == currentWI || EquippedWeaponIndex_2 == currentWI || EquippedWeaponIndex_3 == currentWI)
        {
            EquipBtn.SetActive(false);
            EquippedBtn.SetActive(true);
        }
        SlotManager();
        SaveWeapons();
    }

    void Awake()
    {
        LoadWeapons();
    }

    public void Slot_Selected(int SlotIndex)
    {
        if (currentSlotIdx != SlotIndex)
        {
            SlotChanged = true;
            currentSlotIdx = SlotIndex;
        }
    }

    public void SelectWeapon(int weaponIndex)
    {
        if (currentWI != weaponIndex)
        {
            weaponBtnChanged = true;
            currentWI = weaponIndex;
        }
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == weaponIndex);
        }
    }

    public void EquipClicked()
    {
        EquippedWeaponIndex = currentWI;
        EquipBtn.SetActive(false);
        EquippedBtn.SetActive(true);
    }
    public void WeaponChanged()
    {
        EquipBtn.SetActive(true);
        EquippedBtn.SetActive(false);
    }

    public void SlotManager()
    {
        if (SlotChanged)
        {
            if (currentSlotIdx == 1)
            {
                EquippedWeaponIndex = EquippedWeaponIndex_1;
            }
            if (currentSlotIdx == 2)
            {
                EquippedWeaponIndex = EquippedWeaponIndex_2;
            }
            if (currentSlotIdx == 3)
            {
                EquippedWeaponIndex = EquippedWeaponIndex_3;
            }
        }
        if (currentSlotIdx == 1)
        {
            SlotChanged = false;
            EquippedWeaponIndex_1 = EquippedWeaponIndex;
        }
        if (currentSlotIdx == 2)
        {
            SlotChanged = false;
            EquippedWeaponIndex_2 = EquippedWeaponIndex;
        }
        if (currentSlotIdx == 3)
        {
            SlotChanged = false;
            EquippedWeaponIndex_3 = EquippedWeaponIndex;
        }
    }

    private void SaveWeapons()
    {
        PlayerPrefs.SetInt("EquippedWeaponIndex_1", EquippedWeaponIndex_1);
        PlayerPrefs.SetInt("EquippedWeaponIndex_2", EquippedWeaponIndex_2);
        PlayerPrefs.SetInt("EquippedWeaponIndex_3", EquippedWeaponIndex_3);
        PlayerPrefs.Save();
    }
    private void LoadWeapons()
    {
        EquippedWeaponIndex_1 = PlayerPrefs.GetInt("EquippedWeaponIndex_1", 0);
        EquippedWeaponIndex_2 = PlayerPrefs.GetInt("EquippedWeaponIndex_2", 99);
        EquippedWeaponIndex_3 = PlayerPrefs.GetInt("EquippedWeaponIndex_3", 99);
    }
}