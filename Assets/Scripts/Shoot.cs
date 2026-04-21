using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Transform shootOrigin;

    [SerializeField] private float shootRange = 50.0f;
    [SerializeField] private int shootDamage = 2;

    private void Awake()
    {
        shootOrigin = this.transform;
    }

    public void ShootRayCast()
    {
        Ray ray = new Ray(shootOrigin.position, shootOrigin.forward);
        RaycastHit hit;

        Debug.DrawRay(shootOrigin.position, shootOrigin.forward * shootRange, Color.red, 1f);

        if (Physics.Raycast(ray, out hit, shootRange))
        {   
            // Le ha dado a algo
            Health health = hit.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(shootDamage);
            }
        }
    }
}
