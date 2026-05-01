using UnityEngine;

public class RangedEnemy : Enemy
{
    private Shoot shoot;

    protected override void Awake()
    {
        base.Awake();
        shoot = GetComponentInChildren<Shoot>();
    }

    protected override void HandleBehaviour()
    {
        // implementar comportamiento del enemigo a rango: te mira y te dispara
        Vector3 targetPosition = player.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
        shoot.ShootRayCast();
    }
}
