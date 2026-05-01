using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int currentHealth;
    [SerializeField] private int maxHealth = 5;

    public Action OnDeath;
    public Action<int> OnHealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public int GetHealth() => currentHealth;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath?.Invoke();
        }
    }
}
