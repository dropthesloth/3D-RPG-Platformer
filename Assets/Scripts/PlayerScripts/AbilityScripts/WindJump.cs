using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindJump : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    [HideInInspector ]public float jumpForce;
    public bool canWindJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        canWindJump = true;
        jumpForce = 16f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DoubleJump()
    {
        if (canWindJump)
        {
        rb.velocity = Vector3.up * jumpForce;
        canWindJump = false;
        }
    }
}
