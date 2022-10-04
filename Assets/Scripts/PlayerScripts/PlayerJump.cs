using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [HideInInspector]public Rigidbody rb;
    public float jumpForce;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        isGrounded = true;
    }

    public void Jump()
    {
        if (isGrounded) 
        {
            float currentAccelerationForce = Mathf.Abs(rb.mass * Physics.gravity.y);
            float newJumpForce = jumpForce + currentAccelerationForce;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //rb.velocity = Vector3.up * jumpForce;
            isGrounded = false;
        }
    }
}
