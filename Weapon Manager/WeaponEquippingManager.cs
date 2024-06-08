using UnityEngine;
using UnityEngine.UI;

public class WeaponEquippingManager : MonoBehaviour
{
    public WeaponSlotManager weaponSlotManager;
    public WeaponManager weaponManager;
    public Button equipButton;
    public Button equippedButton;
    public Button[] weaponButtons; // Array of weapon buttons

    public Image weaponImage; // Reference to the weapon image UI element
    public Text weaponNameText; // Reference to the weapon name text UI element
    public Text weaponTypeText; // Reference to the weapon type text UI element

    private int currentSelectedWeapon = -1;

    // Assuming you have a Weapon class that holds weapon data
    [System.Serializable]
    public class Weapon
    {
        public Sprite image;
        public string name;
        public string type;
    }

    public Weapon[] weapons; // Array of weapon data

    void Start()
    {
        equipButton.onClick.AddListener(OnEquipButtonClicked);
        equippedButton.gameObject.SetActive(false);

        for (int i = 0; i < weaponButtons.Length; i++)
        {
            int index = i;
            weaponButtons[i].onClick.AddListener(() => OnWeaponButtonClicked(index));
        }
    }

    void OnWeaponButtonClicked(int index)
    {
        currentSelectedWeapon = index;
        equipButton.gameObject.SetActive(true);
        equippedButton.gameObject.SetActive(false);

        // Update the weapon image and details
        weaponImage.sprite = weapons[index].image;
        weaponNameText.text = weapons[index].name;
        weaponTypeText.text = weapons[index].type;

        // Select weapon in WeaponManager
        weaponManager.SelectWeapon(index);

        Debug.Log($"Weapon {index + 1} selected.");
    }

    void OnEquipButtonClicked()
    {
        if (currentSelectedWeapon != -1 && weaponSlotManager.selectedSlotIndex != -1)
        {
            // Equip the weapon in the slot
            Debug.Log($"Equipped Weapon {currentSelectedWeapon + 1} in Slot {weaponSlotManager.selectedSlotIndex + 1}");

            // Show "Equipped" button and hide "Equip" button
            equipButton.gameObject.SetActive(false);
            equippedButton.gameObject.SetActive(true);

            // Log the equipped weapon
            Debug.Log($"Weapon {currentSelectedWeapon + 1} is now equipped in Slot {weaponSlotManager.selectedSlotIndex + 1}");
        }
    }
}
