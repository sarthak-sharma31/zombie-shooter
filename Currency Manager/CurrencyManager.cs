using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    public int coins = 1000;
    public int crystals = 500;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this instance across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        LoadCurrency();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        SaveCurrency();
    }

    public void SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            SaveCurrency();
        }
    }

    public void AddCrystals(int amount)
    {
        crystals += amount;
        SaveCurrency();
    }

    public void SpendCrystals(int amount)
    {
        if (crystals >= amount)
        {
            crystals -= amount;
            SaveCurrency();
        }
    }

    private void SaveCurrency()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("Crystals", crystals);
        PlayerPrefs.Save();
    }

    private void LoadCurrency()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
        crystals = PlayerPrefs.GetInt("Crystals", 0);
    }
}
