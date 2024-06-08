using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotManager : MonoBehaviour
{
    public Button[] weaponSlotButtons;
    public GameObject equippingPanel;

    public int selectedSlotIndex = -1;

    void Start()
    {
        for (int i = 0; i < weaponSlotButtons.Length; i++)
        {
            int index = i;
            weaponSlotButtons[i].onClick.AddListener(() => OnWeaponSlotClicked(index));
        }
    }

    void OnWeaponSlotClicked(int index)
    {
        selectedSlotIndex = index;
        equippingPanel.SetActive(true);
        Debug.Log($"Slot {index + 1} clicked.");
    }
}
