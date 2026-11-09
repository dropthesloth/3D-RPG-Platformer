using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator playerAnim;
    [SerializeField] Movement moveRef;
    [SerializeField] PlayerJump jumpRef;
    [SerializeField] PlayerInputKeyboard inputRef;
    bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        jumpRef.GroundedEvent += GroundedCheck;
        if (inputRef != null)
            inputRef.MoveInput.action.performed += StartMoving;
    }
    private void OnDisable()
    {
        jumpRef.GroundedEvent -= GroundedCheck;
        if (inputRef != null)
            inputRef.MoveInput.action.performed -= StartMoving;
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
    void StartMoving(InputAction.CallbackContext context)
    {

        if (!isMoving && moveRef.isMoving)
        {
            Debug.Log("Haiyaa");
            playerAnim.SetBool("IsRunning", moveRef.isMoving);
            isMoving = true;
            StartCoroutine(MovingCheck());
            
        }
    }

    IEnumerator MovingCheck()
    {
        yield return new WaitForSeconds(0.05f);
        while (moveRef.speed / moveRef.maxSpeed > 0.05f)
        {
            playerAnim.SetFloat("Velocity", moveRef.speed / moveRef.maxSpeed);
            yield return new WaitForEndOfFrame();
            Debug.Log("Do be running");
        }
        yield return new WaitForEndOfFrame();
        Debug.Log("Do be stopped");
        if (!moveRef.isMoving)
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
