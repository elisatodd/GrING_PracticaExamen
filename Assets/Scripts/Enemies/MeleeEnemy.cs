using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private int damage = 1;

    protected override void HandleBehaviour()
    {
        agent.SetDestination(player.transform.position);

        int resto;
        int resultadoDeLaDivision = Division(1, 2, out resto);

        int vidaEnemigo = 100;
        int cantidad = 50;
        AplicarDanio(cantidad, ref vidaEnemigo);
        // vidaEnemigo = 100 - 50 = 50;
        // cantidad = 50;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health h;
      //   if (collision.gameObject.CompareTag("Player"))
        
      // if (collision.gameObject.GetComponent<PlayerController>())

        if (h = collision.gameObject.GetComponent<Health>())
        {
            h.TakeDamage(damage);
        }
    }

    int Division(float a, float b, out int resto)
    {
        resto = (int)(a%b);
        return (int)(a/b);
    }

    void AplicarDanio(int cantidad, ref int vidaEnemigo)
    {
        if (vidaEnemigo > 0)
        {
            vidaEnemigo -= cantidad;
        }

        cantidad = 10000000;
    }
}