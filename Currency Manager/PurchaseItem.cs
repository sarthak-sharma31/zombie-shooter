using UnityEngine;

public class PurchaseItem : MonoBehaviour
{
    public int itemCostInCrystals; // The cost of the item in crystals

    public void Purchase()
    {
        if (CurrencyManager.Instance.crystals >= itemCostInCrystals) // Check if the player has enough crystals
        {
            CurrencyManager.Instance.SpendCrystals(itemCostInCrystals); // Deduct the cost from the player's crystals
            // Optionally, update the UI if necessary
            FindObjectOfType<CurrencyUI>().UpdateCurrencyUI();
            // Handle the purchased item (e.g., add to inventory)
            Debug.Log("Item Purchased!");
        }
        else
        {
            Debug.Log("Not enough crystals!");
        }
    }
}
