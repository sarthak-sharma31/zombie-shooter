using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Consumable
{
    public string name;
    public int quantity;

    public Consumable(string name, int quantity)
    {
        this.name = name;
        this.quantity = quantity;
    }
}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Consumable> consumables = new List<Consumable>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize with some consumables (example)
        consumables.Add(new Consumable("Health", 5));
        consumables.Add(new Consumable("Armor", 3));
    }

    public void UseItem(string itemName)
    {
        Consumable item = consumables.Find(c => c.name == itemName);
        if (item != null && item.quantity > 0)
        {
            item.quantity--;
        }
    }

    public void AddConsumable(string name, int amount)
    {
        Consumable consumable = consumables.Find(c => c.name == name);
        if (consumable != null)
        {
            consumable.quantity += amount;
        }
        else
        {
            consumables.Add(new Consumable(name, amount));
        }

        UpdateUI();
    }

    public bool UseConsumable(string name)
    {
        Consumable consumable = consumables.Find(c => c.name == name);
        if (consumable != null && consumable.quantity > 0)
        {
            consumable.quantity--;
            UpdateUI();
            return true;
        }
        return false;
    }

    void UpdateUI()
    {
        // Update the UI to reflect the current inventory
        // This function should be implemented to update the UI elements
        ConsumableUIManager.Instance.UpdateUI();
    }
}
