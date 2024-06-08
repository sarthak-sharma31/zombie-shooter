using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthSlider;
    public Slider EaseSlider_H;
    public Slider ArmorSlider;
    public Slider EaseSlider_A;
    public float maxHealth = 100f;
    float maxArmor;
    public float currentHealth;
    public float currentArmor;
    private float LerpSpeed = 0.05f;
    public bool armorInUse;

    void Start()
    {
        maxArmor = maxHealth / 2;
        currentHealth = maxHealth;
        currentArmor = 0f;
        HealthSlider.maxValue = maxHealth;
        ArmorSlider.maxValue = maxArmor;
        HealthSlider.value = currentHealth;
        ArmorSlider.value = currentArmor;
        EaseSlider_H.value = currentHealth;
        EaseSlider_A.value = currentArmor;
        armorInUse = false;
    }

    void Update()
    {
        if (armorInUse)
        {
            if (ArmorSlider.value != currentArmor)
            {
                ArmorSlider.value = currentArmor;
            }
            if (ArmorSlider.value != EaseSlider_A.value)
            {
                EaseSlider_A.value = Mathf.Lerp(EaseSlider_A.value, currentArmor, LerpSpeed);
            }
        }
        if(!armorInUse)
        {
            EaseSlider_A.value = Mathf.Lerp(EaseSlider_A.value, 0, LerpSpeed);
        }

        if (HealthSlider.value != currentHealth)
        {
            HealthSlider.value = currentHealth;
        }
        if (HealthSlider.value != EaseSlider_H.value)
        {
            EaseSlider_H.value = Mathf.Lerp(EaseSlider_H.value, currentHealth, LerpSpeed);
        }

        if (currentArmor <= 0)
        {
            armorInUse = false;
        }
    }

    public void UseArmor()
    {
        if (currentArmor < maxArmor)
        {
            armorInUse = true;
            currentArmor = maxArmor;
            InventoryManager.Instance.UseItem("Armor");
            ConsumableUIManager.Instance.UpdateUI();
        }
    }

    public void UseHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = maxHealth;
            InventoryManager.Instance.UseItem("Health");
            ConsumableUIManager.Instance.UpdateUI();
        }
    }

    public void TakeDamage(float amount)
    {
        if (armorInUse)
        {
            currentArmor -= amount;
            if (currentArmor < 0)
            {
                currentHealth += currentArmor; // subtract the overflow damage from health
                currentArmor = 0;
                armorInUse = false;
            }
        }
        else
        {
            currentHealth -= amount;
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("GameOver");
        // Implement additional game over logic here
    }
}
