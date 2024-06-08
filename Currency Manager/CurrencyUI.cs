using UnityEngine;
using TMPro;

public class CurrencyUI : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI crystalsText;

    void Start()
    {
        UpdateCurrencyUI();
    }

    void OnEnable()
    {
        UpdateCurrencyUI();
    }

    public void UpdateCurrencyUI()
    {
        if (CurrencyManager.Instance != null)
        {
            coinsText.text = CurrencyManager.Instance.coins.ToString();
            crystalsText.text = CurrencyManager.Instance.crystals.ToString();
        }
    }
}
