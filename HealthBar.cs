using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    private Health zombieHealth;

    void Start()
    {
        zombieHealth = GetComponentInParent<Health>();
        if (zombieHealth == null)
        {
            Debug.LogError("Health component not found on parent GameObject.");
        }
    }

    void Update()
    {
        if (zombieHealth != null)
        {
            healthBarImage.fillAmount = zombieHealth.currentHealth / zombieHealth.maxHealth;
        }
    }
}
