using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    public float maxHealth;
    public float currentHealth;
    public bool isDead;
    
    public event Action<float> OnHealthChanged;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth / maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Min(currentHealth - damage, maxHealth);
        OnHealthChanged?.Invoke(currentHealth / maxHealth);
        if (currentHealth <= 0f) Die();
    }

    void Die()
    {
        isDead = true;
    }
}
