using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindJump : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public float jumpForce;
    public bool canWindJump;
    bool charging;
    Animator anim;
    //When I can add more combat focus. Will blow other enemies and any projectiles away
    // GameObject windBox;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        charging = false;
        rb = gameObject.GetComponent<Rigidbody>();
        canWindJump = true;
        jumpForce = 30f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator ExecuteWindJump()
    {
        anim.SetBool("WindJumping", true);
        anim.SetBool("ChargingJump", true);
        charging = true;
        float chargeTimer = 1f;
        while (charging)
        {
            rb.linearDamping = 30f;
            chargeTimer -= Time.deltaTime;
            Debug.Log("Timer is now " + chargeTimer.ToString("F2"));
            if(chargeTimer  < 0f)
                charging = false;
            yield return new WaitForEndOfFrame();
        }
        StopCharging();
        yield return new WaitForEndOfFrame();
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        yield return new WaitForEndOfFrame();
        anim.SetBool("WindJumping", false);
    }
    public void StopCharging()
    {
        rb.linearDamping = 0f;
        anim.SetBool("ChargingJump", false);        
    }
    public void DoubleJump()
    {
        if (canWindJump)
        {
            StartCoroutine(ExecuteWindJump());            
           // if (rb.linearVelocity.y < 0)
            //    rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
           //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // rb.linearVelocity = Vector3.up * jumpForce;
            //canWindJump = false;
        }
    }
}
