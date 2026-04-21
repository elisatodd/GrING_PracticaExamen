using UnityEngine;

public class PlayerController : MovementController
{
    public override void Move() 
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDir = m_transform.right * h + m_transform.forward * v; // up == (0,1,0) right == (1,0,0) forward == (0,0,1)

        Vector3 velocity = moveDir * moveSpeed;
        velocity.y = m_rigidbody.linearVelocity.y;

        m_rigidbody.linearVelocity = velocity;
    }
}
