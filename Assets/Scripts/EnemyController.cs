using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MovementController
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;

    //public override void Move()
    //{
    //    agent.SetDestination(target.position);
    //}
}
