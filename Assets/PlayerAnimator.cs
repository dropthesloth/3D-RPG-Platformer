using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAnimator : MonoBehaviour
{
    private static readonly int VelocityHash = Animator.StringToHash("Velocity");
    [SerializeField] Animator playerAnim;
    [SerializeField] Movement moveRef;
    [SerializeField] PlayerJump jumpRef;
    [SerializeField] PlayerInputKeyboard inputRef;
    [SerializeField] bool isMoving;
    /*float PlayerVelocity { get { return moveRef.speed; } 
                           set { PlayerVelocity = value;  playerAnim.SetFloat(VelocityHash, value / moveRef.maxSpeed); Debug.Log("Do be moving"); } }*/
    // bool IsMoving { get { return moveRef.isMoving; } set { } }
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        jumpRef.GroundedEvent += GroundedCheck;
        if (inputRef != null)
        {
            inputRef.MoveInput.action.performed += StartMoving;
        }
    }
    private void OnDisable()
    {
        jumpRef.GroundedEvent -= GroundedCheck;
        if (inputRef != null)
            inputRef.MoveInput.action.performed -= StartMoving;
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
        if (!playerAnim.GetBool("IsRunning") && moveRef.isMoving)
        {
            Debug.Log("Start moving");
            playerAnim.SetBool("IsRunning", true);
            isMoving = true;
            StartCoroutine(MovingCheck());
        }
    }

    IEnumerator MovingCheck()
    {
        if (moveRef.speed / moveRef.maxSpeed > 0.01f)
            Debug.Log("Do be moving");
        //yield return new WaitForSeconds(0.05f);
        while (moveRef.speed / moveRef.maxSpeed > 0.01f)
        {
            playerAnim.SetFloat("Velocity", moveRef.speed / moveRef.maxSpeed);
            Debug.Log("Do be running");
            yield return new WaitForEndOfFrame();
        }
        //yield return new WaitForEndOfFrame();
        Debug.Log("Do be stopped");
        if (!moveRef.isMoving)
            playerAnim.SetFloat("Velocity", 0);
        playerAnim.SetBool("IsRunning", false);
        isMoving = false;
        yield return new WaitForEndOfFrame();
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
