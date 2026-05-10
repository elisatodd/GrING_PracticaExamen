using 
    System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{
    private Transform shootOrigin;

    [SerializeField] private float shootRange = 50.0f;
    [SerializeField] private int shootDamage = 2;

    [SerializeField] private int initialAmmo = 5;
    private int currentAmmo;

    [SerializeField] private float fireRate = 5.0f;
    private float lastShotTime;

    private LineRenderer lineRenderer;
    [SerializeField] private float lineDuration = 0.1f;


    private void Awake()
    {
        shootOrigin = this.transform;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        currentAmmo = initialAmmo;
        lastShotTime = 0;
    }

    public void ShootRayCast()
    {
        if (currentAmmo > 0 && ((lastShotTime == 0) || lastShotTime + fireRate <= Time.time))
        {
            Ray ray = new Ray(shootOrigin.position, shootOrigin.forward);
            RaycastHit hit;

            // Debug.DrawRay(shootOrigin.position, shootOrigin.forward * shootRange, Color.red, 1f);

            Vector3 endPoint = shootOrigin.position + shootOrigin.forward * shootRange;
                
            if (Physics.Raycast(ray, out hit, shootRange))
            {
                endPoint = hit.point;

                // Le ha dado a algo
                Health health = hit.collider.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(shootDamage);
                }
            }

            StartCoroutine(ShowLine(shootOrigin.position, endPoint));

            currentAmmo--;
            lastShotTime = Time.time;
        }
    }

    IEnumerator ShowLine(Vector3 start, Vector3 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(lineDuration);

        lineRenderer.enabled = false;
    }

}
