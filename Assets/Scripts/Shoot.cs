using UnityEngine;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{
    private Transform shootOrigin;

    [SerializeField] private float shootRange = 50.0f;
    [SerializeField] private int shootDamage = 2;

    [SerializeField] private int ammo = 5;

    [SerializeField] private float fireRate = 2.0f;
    float lastShotTime;


    private void Awake()
    {
        shootOrigin = this.transform;
    }

    public void ShootRayCast()
    {
        if (ammo > 0 && (lastShotTime + fireRate <= Time.time))
        {
            Ray ray = new Ray(shootOrigin.position, shootOrigin.forward);
            RaycastHit hit;

            Debug.DrawRay(shootOrigin.position, shootOrigin.forward * shootRange, Color.red, 1f);

                Debug.Log("he disparado");
            if (Physics.Raycast(ray, out hit, shootRange))
            {
                // Le ha dado a algo
                Health health = hit.collider.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(shootDamage);
                }
            }
            ammo--;

            lastShotTime = Time.time;
        }
    }
}
