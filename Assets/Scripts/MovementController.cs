using UnityEngine;

[RequireComponent (typeof(Transform))]
[RequireComponent (typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{
    protected Rigidbody m_rigidbody;
    protected Transform m_transform;
    [SerializeField] protected float moveSpeed = 3.0f;

    private void Awake()
    {
        m_transform = GetComponent<Transform>(); // .transform == GetComponent<Transform>()
        m_rigidbody = GetComponent<Rigidbody>();
    }
    public virtual void Move() { }

    private void FixedUpdate()
    {
        Move();
    }
}
