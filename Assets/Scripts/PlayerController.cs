using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private Shoot m_shoot;

    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float rotationSpeed = 1.5f;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_shoot = GetComponentInChildren<Shoot>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() // Movimiento del raton
    {
        // Debug.Log("Mouse x : " + Input.GetAxis("Mouse X") + " . Mouse y : " + Input.GetAxis("Mouse Y"));
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(mouseX * rotationSpeed * transform.up); // * Vector3.up

        //transform.Rotate(mouseY*rotationSpeed*transform.right);

        //cameraTransform.Rotate(-1 * mouseY * rotationSpeed * Vector3.right);

        // Método más correcto :)
        float rotationCamera = cameraTransform.localRotation.eulerAngles.x + (-1 * mouseY * rotationSpeed);

        float maxRotation = 90.0f;
        Mathf.Clamp(rotationCamera, -maxRotation, maxRotation);

        cameraTransform.localRotation = Quaternion.Euler(rotationCamera, 0, 0);

        if (Input.GetMouseButtonDown(0))
        {
            if (m_shoot)
            {
                m_shoot.ShootRayCast();
            }
        }
    }

    void FixedUpdate() // Movimiento de las teclas
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDir = transform.right * h + transform.forward * v; // up == (0,1,0) right == (1,0,0) forward == (0,0,1)

        Vector3 velocity = moveDir * moveSpeed;
        velocity.y = m_rigidbody.linearVelocity.y;

        m_rigidbody.linearVelocity = velocity;
    }
}
