using UnityEngine;
using TMPro;

public class ConsumableUIManager : MonoBehaviour
{
    public static ConsumableUIManager Instance;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI armorText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        Consumable health = InventoryManager.Instance.consumables.Find(c => c.name == "Health");
        Consumable armor = InventoryManager.Instance.consumables.Find(c => c.name == "Armor");

        if (health != null)
        {
            healthText.text = "" + health.quantity;
        }
        if (armor != null)
        {
            armorText.text = "" + armor.quantity;
        }
    }
}
