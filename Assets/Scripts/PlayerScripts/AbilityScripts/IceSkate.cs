using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSkate : MonoBehaviour
{

    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public float skateSpeed;
    [HideInInspector] public bool canSkate;
    public float dashTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        canSkate  = false;
        skateSpeed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        if (dashTimer > 0)
        {
            float movementX = Input.GetAxis("Horizontal");
            float movementZ = Input.GetAxis("Vertical"); 
            rb.linearVelocity = new Vector3(movementX * skateSpeed, 0, movementZ * skateSpeed);
            dashTimer -= Time.deltaTime;
        }
    }
    public void Dash()
    {
        dashTimer = 3f;
    }
}
