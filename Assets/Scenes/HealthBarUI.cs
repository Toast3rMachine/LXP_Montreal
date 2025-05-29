using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthBar;
    public Health targetHealth;
    
    public GameObject HealthUIFill;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (targetHealth != null)
        {
            targetHealth.OnHealthChanged += UpdateHealthBar;
            UpdateHealthBar(targetHealth.maxHealth / 20);
        }
    }

    // Update is called once per frame
    void UpdateHealthBar(float currentHealth)
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
            HealthUIFill.SetActive(currentHealth > 0f);
        }
    }

    void OnDestroy()
    {
        if  (targetHealth != null)
        {
        targetHealth.OnHealthChanged -= UpdateHealthBar;
        }
    }
}
