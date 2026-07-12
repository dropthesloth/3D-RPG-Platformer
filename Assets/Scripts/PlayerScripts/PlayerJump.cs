using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public bool isGrounded { get { return _grounded; } 
                           set { _grounded = value; GroundedEvent.Invoke(value); } }
    public bool _grounded;
    public event Action<bool> GroundedEvent;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
    }

    public void Jump()
    {
        if (isGrounded) 
        {
            float currentAccelerationForce = Mathf.Abs(rb.mass * Physics.gravity.y);
            float newJumpForce = jumpForce + currentAccelerationForce;
            //rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //rb.velocity = Vector3.up * jumpForce;
            isGrounded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            isGrounded = true;
            Debug.Log("ur");
        }
    }
}
