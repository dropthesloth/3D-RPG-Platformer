using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindJump : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public float jumpForce;
    public bool canWindJump;
    //When I can add more combat focus. Will blow other enemies and any projectiles away
   // GameObject windBox;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        canWindJump = true;
        jumpForce = 30f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DoubleJump()
    {
        if (canWindJump)
        {
            if (rb.linearVelocity.y < 0)
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // rb.linearVelocity = Vector3.up * jumpForce;
            canWindJump = false;
        }
    }
}
