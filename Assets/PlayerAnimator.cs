using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator playerAnim;
    [SerializeField] Movement moveRef;
    [SerializeField] PlayerJump jumpRef;
    [SerializeField] PlayerController playerControllerRef;
    bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        jumpRef.GroundedEvent += GroundedCheck;
        if (playerControllerRef.playerInputInterface != null)
            playerControllerRef.playerInputInterface.MoveInput += StartMoving;
    }
    private void OnDisable()
    {
        jumpRef.GroundedEvent -= GroundedCheck;
        if (playerControllerRef.playerInputInterface != null)
            playerControllerRef.playerInputInterface.MoveInput -= StartMoving;
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void GroundedCheck(bool isGrounded)
    {
        playerAnim.SetBool("IsGrounded", isGrounded);
        if (!isGrounded)
            StartCoroutine(WhenAirborne());
        else
            playerAnim.SetFloat("VerticalVelocity", 0);
    }
    void StartMoving(Vector3 direction)
    {
        
        if (!isMoving && moveRef.isMoving)
        {
            Debug.Log("Haiyaa");
            playerAnim.SetBool("IsRunning", moveRef.isMoving);
            StartCoroutine(MovingCheck());
            isMoving = true;
        }
    }

    IEnumerator MovingCheck()
    {
        yield return new WaitForSeconds(0.05f);
        while (moveRef.rb.linearVelocity.magnitude > 0.001f)
        {
            playerAnim.SetFloat("Velocity", moveRef.rb.linearVelocity.magnitude / (moveRef.speed * Time.fixedDeltaTime));
            yield return new WaitForEndOfFrame();
        }
        playerAnim.SetFloat("Velocity", 0);
        playerAnim.SetBool("IsRunning", moveRef.isMoving);
        isMoving = false;
    }
    IEnumerator WhenAirborne()
    {
        while (!playerAnim.GetBool("IsGrounded"))
        {
            playerAnim.SetFloat("VerticalVelocity", moveRef.rb.linearVelocity.y);
            yield return new WaitForEndOfFrame();
        }
    }
}
