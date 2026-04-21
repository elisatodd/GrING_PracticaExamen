using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    protected Transform player;

    [SerializeField] private float detectionRange = 1.0f;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // if (distancia al player <= rango de vision)
        //     --> activar comportamiento del enemigo

        float playerToEnemy = Vector3.Distance(this.transform.position, player.position);
        
        if (playerToEnemy <= detectionRange)
        {
            HandleBehaviour();
        }
    }

    private void OnDrawGizmos()
    {
        // Set the color with custom alpha.
        Gizmos.color = new Color(1f, 0f, 0f, 1f); // Red with custom alpha

        // Draw the sphere.
        Gizmos.DrawSphere(transform.position, detectionRange);

        // Draw wire sphere outline.
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    // Comportamiento específico de cada enemigo
    protected abstract void HandleBehaviour();
}