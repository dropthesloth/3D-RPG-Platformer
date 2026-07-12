using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDash : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public float dashForce;
    [HideInInspector] public bool canDash;
    bool charging;
    public float dashTimer;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        charging = false;
        rb = gameObject.GetComponent<Rigidbody>();
        canDash = false;
        dashForce = 20f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dashTimer > 0)
        {
            float movementX = Input.GetAxis("Horizontal");
            float movementZ = Input.GetAxis("Vertical");
            /*if (movementX != 0 || movementZ != 0)
                rb.velocity = new Vector3(movementX * dashForce, 0, movementZ * dashForce);
            else*/
            rb.linearVelocity = transform.forward * dashForce;
            dashTimer -= Time.deltaTime;
        }
    }
    IEnumerator ExecuteFlameDash()
    {
        anim.SetBool("FlameDashing", true);
        anim.SetBool("ChargingJump", true);
        charging = true;
        float chargeTimer = 0.4f;
        while (charging)
        {
            rb.linearDamping = 30f;
            chargeTimer -= Time.deltaTime;
            Debug.Log("Timer is now " + chargeTimer.ToString("F2"));
            if (chargeTimer < 0f)
                charging = false;
            yield return new WaitForEndOfFrame();
        }
        StopCharging();
        yield return new WaitForEndOfFrame();
        rb.linearVelocity += rb.transform.forward * dashForce;
        //rb.AddForce(rb.transform.forward * dashForce, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("FlameDashing", false);
    }
    public void StopCharging()
    {
        rb.linearDamping = 0f;
        anim.SetBool("ChargingJump", false);
    }
    public void Dash()
    {
        StartCoroutine(ExecuteFlameDash());
    }
}
