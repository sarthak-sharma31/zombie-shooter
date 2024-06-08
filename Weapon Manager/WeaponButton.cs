using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    public int weaponIndex; // Index of the weapon
    private WeaponUIManager weaponUIManager;

    private void Start()
    {
        weaponUIManager = FindObjectOfType<WeaponUIManager>();
    }

    public void OnEquipButtonClick()
    {
        weaponUIManager.EquipWeapon(weaponIndex);
    }
}
