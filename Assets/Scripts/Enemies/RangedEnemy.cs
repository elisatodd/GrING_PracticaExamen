using UnityEngine;

[RequireComponent(typeof(Shoot))]
public class RangedEnemy : Enemy
{
    private Shoot shoot;

    protected override void Awake()
    {
        base.Awake();
        shoot = GetComponent<Shoot>();
    }

    protected override void HandleBehaviour()
    {
        // implementar comportamiento del enemigo a rango: te mira y te dispara
        transform.LookAt(player.transform);
        shoot.ShootRayCast();
    }
}
