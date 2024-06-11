using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlots : MonoBehaviour
{
    private WeaponManager weaponManager;
    public int SlotIndex;
    public GameObject SlotPanel;
    public GameObject EquipPanel;

    void Start()
    {
        weaponManager = FindObjectOfType<WeaponManager>();
    }

    public void Clicked()
    {
        SlotPanel.SetActive(false);
        EquipPanel.SetActive(true);
        weaponManager.Slot_Selected(SlotIndex);
    }
}
