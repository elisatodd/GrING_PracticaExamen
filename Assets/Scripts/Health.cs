using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int currentHealth;
    private int maxHealth = 100;

    public Action OnDeath;
    public Action<int> OnHealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public int GetHealth() => currentHealth;

    public void TakeDamage(int amount, ParticleSystem ps = null)
    {
        currentHealth -= amount;
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath?.Invoke();
        }

        if (ps != null)
        {
            // ps...
        }

        sumarF(1, 1);
    }

    int sumar(int a, int b)
    {
        return a + b;
    }
    float sumarF(int a, int b)
    {
        return a + b;
    }

    //public void TakeDamage(int amount, ParticleSystem ps)
    //{
    //    this.TakeDamage(amount);

    //    ps.emissionRate = 10;
    //}
}
