using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    public Transform movingObject;
    [HideInInspector] public Rigidbody rb;
    public float speed;
    public float maxSpeed;
    // float accelerationTime;
    [SerializeField] Transform mainCamera;
    //[SerializeField] CharacterController charCtrl;
    [SerializeField] Animator moveAnim;
    public bool isMoving;
    public Vector3 dir;
    //public Vector3 testVelocity;
    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3.zero;
        rb = gameObject.GetComponent<Rigidbody>();
        isMoving = false;
        //accelerationTime = 0;
        speed = 0;
    }
    public void Move(Vector3 direction)
    {
        Vector3 moveDirection = Vector3.zero;
        Debug.Log("Velocity = " + rb.linearVelocity.ToString());
        Debug.Log("Direction = " + direction.ToString());
        Debug.Log("Magnitude =" + direction.magnitude);
        if (direction.x != 0 || direction.z != 0)
        {
            float playerAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
            rb.MoveRotation(Quaternion.Euler(0f, playerAngle, 0f));
            moveDirection = Quaternion.Euler(0, playerAngle, 0) * Vector3.forward;
        }
        if (direction.magnitude >= 0.1f)
            rb.linearVelocity = new Vector3(moveDirection.x * speed * Time.fixedDeltaTime,
                          rb.linearVelocity.y, moveDirection.z * speed * Time.fixedDeltaTime);
        else
        {

            Debug.Log("cummy cumdrop");
        }
        //isMoving = direction.magnitude >= 0.1f;

    }
    public IEnumerator Accelerate(Vector3 direction)
    {
        isMoving = true;
        Debug.Log("jark");
        while (direction.magnitude > 0.1f && speed < maxSpeed && isMoving)
        {
            speed += maxSpeed / 5;
            yield return new WaitForSeconds(0.1f);
        }
        speed = maxSpeed;
    }
    public IEnumerator Decelerate(Vector3 direction)
    {
        isMoving = false;
        Debug.Log("coom");
        while (speed > 0 && direction.magnitude <= 0.9f && !isMoving)
        {
            speed -= maxSpeed / 10;
            if (rb.linearVelocity.x != 0 || rb.linearVelocity.z != 0)
                rb.linearVelocity = new Vector3(rb.linearVelocity.x / 1.2f, rb.linearVelocity.y,
                                                    rb.linearVelocity.z / 1.2f);
            yield return new WaitForSeconds(0.05f);
        }
        //rb.linearVelocity = new Vector3(0,rb.linearVelocity.y,0);
        speed = 0;
    }
}
