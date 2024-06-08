using UnityEngine;
using UnityEngine.UI;

public class SlotButton : MonoBehaviour
{
    public int slotIndex; // Index of the slot (1, 2, 3, etc.)
    public GameObject weaponEquippingPanel;
    private WeaponUIManager weaponUIManager;

    private void Start()
    {
        weaponUIManager = FindObjectOfType<WeaponUIManager>();
    }

    public void OnSlotClick()
    {
        weaponUIManager.SetCurrentSlot(slotIndex);
        weaponEquippingPanel.SetActive(true);
    }
}
