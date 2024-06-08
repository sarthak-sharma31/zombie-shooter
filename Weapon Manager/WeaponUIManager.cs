using UnityEngine;
using UnityEngine.UI;

public class WeaponUIManager : MonoBehaviour
{
    public GameObject[] weaponButtons;
    public Button equipButton;
    public Button equippedButton;
    private int currentSlot;
    private int[] equippedWeapons; // Array to track which weapon is equipped in each slot

    private void Start()
    {
        equippedWeapons = new int[weaponButtons.Length]; // Initialize with default values
        for (int i = 0; i < equippedWeapons.Length; i++)
        {
            equippedWeapons[i] = -1; // -1 indicates no weapon equipped
        }

        // Initialize the Equip and Equipped button states
        equipButton.gameObject.SetActive(true);
        equippedButton.gameObject.SetActive(false);
    }

    public void SetCurrentSlot(int slotIndex)
    {
        currentSlot = slotIndex;
    }

    public void EquipWeapon(int weaponIndex)
    {
        equippedWeapons[currentSlot] = weaponIndex;
        Debug.Log("Equipped weapon " + weaponIndex + " in slot " + currentSlot);
        UpdateEquipButtons(weaponIndex);
    }

    private void UpdateEquipButtons(int weaponIndex)
    {
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            if (i == weaponIndex)
            {
                weaponButtons[i].transform.Find("EquipButton").gameObject.SetActive(false);
                weaponButtons[i].transform.Find("EquippedButton").gameObject.SetActive(true);
            }
            else
            {
                weaponButtons[i].transform.Find("EquipButton").gameObject.SetActive(true);
                weaponButtons[i].transform.Find("EquippedButton").gameObject.SetActive(false);
            }
        }
    }
}
