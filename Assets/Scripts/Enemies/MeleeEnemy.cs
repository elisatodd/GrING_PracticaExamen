using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private int damage = 1;

    protected override void HandleBehaviour()
    {
        if (agent.destination != player.transform.position)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health h;
        if (h = collision.gameObject.GetComponent<Health>())
        {
            h.TakeDamage(damage);
        }
    }
}