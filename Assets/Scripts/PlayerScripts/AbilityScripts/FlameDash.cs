using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDash : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public float dashForce;
    [HideInInspector] public bool canDash;
    public float dashTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        canDash = false;
        dashForce = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (dashTimer > 0)
        {
            float movementX = Input.GetAxis("Horizontal");
            float movementZ = Input.GetAxis("Vertical");
            /*if (movementX != 0 || movementZ != 0)
                rb.velocity = new Vector3(movementX * dashForce, 0, movementZ * dashForce);
            else*/
            rb.velocity = transform.forward * dashForce;
            dashTimer -= Time.deltaTime;
        }
    }
    public void Dash()
    {
        dashTimer = 0.5f;
    }
}
