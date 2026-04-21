using UnityEngine;

[RequireComponent (typeof(Transform))]
public class Entity : MonoBehaviour
{
    protected Health m_health;
    protected MovementController m_movementController;

    public virtual void Awake()
    {
        m_health = GetComponent<Health>();
        m_movementController = GetComponent<MovementController>();
    }

    public void TakeDamage(int damageReceived)
    {
        m_health?.TakeDamage(damageReceived);
    }

    public void Heal(int healthRestored)
    {
        m_health?.TakeDamage(-healthRestored);
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
