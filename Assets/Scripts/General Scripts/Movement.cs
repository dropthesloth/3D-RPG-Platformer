using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform movingObject;
    [HideInInspector] public Rigidbody rb;
    public float speed;
    [SerializeField] Transform mainCamera;
    //[SerializeField] CharacterController charCtrl;
    [SerializeField] Animator moveAnim;
    public bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.position += new Vector3 (movementX * speed, 0, movementZ * speed);
        //rb.position += new Vector3(movementX * speed, 0, movementZ * speed);
    }
    public void Move(Vector3 direction)
    {
        direction = direction.normalized;
        Debug.Log(direction.ToString());
        if (direction.x != 0 || direction.z != 0)
        {
            float playerAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
            rb.MoveRotation(Quaternion.Euler(0f, playerAngle, 0f));

            Vector3 moveDirection = Quaternion.Euler(0, playerAngle, 0) * Vector3.forward;

            moveDirection = moveDirection.normalized;
            if (direction.magnitude >= 0.1f)
            {
                rb.linearVelocity = new Vector3(moveDirection.x * speed * Time.fixedDeltaTime, rb.linearVelocity.y, moveDirection.z * speed * Time.fixedDeltaTime);
                // moveAnim.SetBool("IsRunning", true);
                isMoving = true;
            }
        }
        else
        {
            // moveAnim.SetBool("IsRunning", false);
            isMoving = false;
            //rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            Debug.Log("Current vertical velocity = " + rb.linearVelocity.magnitude.ToString());
        }
    }
}
