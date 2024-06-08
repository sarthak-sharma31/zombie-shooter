using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider HealthSlider;
    public Slider EaseSlider;
    public float maxHealth = 100f;
    public float currentHealth;
    private float LerpSpeed = 0.05f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(HealthSlider.value != currentHealth){
            HealthSlider.value = currentHealth;
        }
        if(HealthSlider.value != EaseSlider.value){
            EaseSlider.value = Mathf.Lerp(EaseSlider.value, currentHealth, LerpSpeed);
        }
    }

    public void TakeDamage(float amount)
    {
            currentHealth -= amount;
            if (currentHealth <= 0f)
            {
                Die();
            }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}