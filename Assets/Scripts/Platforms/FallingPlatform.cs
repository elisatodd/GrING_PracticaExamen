using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [Header("Timings")]
    [SerializeField] private float fallDelay = 0.7f;  // tiempo antes de caer
    [SerializeField] private float resetDelay = 1.5f; // tiempo en el suelo

    [Header("Fall Settings")]
    [SerializeField] private float fallSpeed = 5f;
    [SerializeField] private float minY = -5f;

    private Vector3 startPosition;
    private Rigidbody rb;

    private bool fallTriggered = false;
    private bool isFalling = false;
    private bool isResetting = false;

    private float fallStartTime;   // momento en que se activo la caida
    private float resetStartTime;  // momento en que toco suelo

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        startPosition = rb.position;
    }

    private void FixedUpdate()
    {
        float t = Time.time;

        // 1. Iniciar caida tras fallDelay
        if (fallTriggered && !isFalling && !isResetting)
        {
            if (t >= fallStartTime + fallDelay)
            {
                isFalling = true;
            }
        }

        // 2. Caida
        if (isFalling)
        {
            Vector3 newPos = rb.position + Vector3.down * fallSpeed * Time.fixedDeltaTime;

            // Limitar al suelo
            if (newPos.y <= minY)
            {
                newPos.y = minY;
                isFalling = false;
                isResetting = true;
                resetStartTime = t; // iniciar timer de reset
            }

            rb.MovePosition(newPos);
        }

        // 3️. Reinicio tras resetDelay
        if (isResetting)
        {
            if (t >= resetStartTime + resetDelay)
            {
                rb.position = startPosition;

                fallTriggered = false;
                isFalling = false;
                isResetting = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!fallTriggered && collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                // Solo activamos si el jugador pisa la parte superior
                if (contact.normal.y < -0.5f)
                {
                    fallTriggered = true;
                    fallStartTime = Time.time;
                    return;
                }
            }
        }
    }
}