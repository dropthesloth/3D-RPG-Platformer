using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public bool hasDoubleJump;
    PlayerJump playerJumpRef;
    //PlayerInputKeyboard playerInput;
    // PlayerInputController playerInputC;
    [HideInInspector] public IPlayerInput playerInputInterface;
    [HideInInspector] public WindJump windJumpRef;
    [HideInInspector] public FlameDash flameDashRef;
    [HideInInspector] public ProjectileShoot projectileShootRef;
    [SerializeField] GameObject menu;
    Movement movementRef;
    CameraController cameraControlRef;
    private void Awake()
    {
        //playerInput = GetComponent<PlayerInputKeyboard>();
        //playerInputInterface = GetComponent<IPlayerInput>();
        movementRef = GetComponent<Movement>();
        playerJumpRef = GetComponent<PlayerJump>();
        cameraControlRef = GetComponent<CameraController>();
        //playerInput.MoveInput += movementRef.Move;
        //playerInput.JumpInput += playerJumpRef.Jump;

        StartingInput();
        //KeyboardInput();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerJumpRef.isGrounded == false)
        {
            //Checks if the player can Wind Jump
            if (GetComponent<WindJump>())
            {
                if (windJumpRef.canWindJump)
                {
                    /*if (GetComponent<PlayerInputController>() && playerInputC.abilityReady)
                        Debug.Log("Testing testing");//playerInputC.abilityReady = false;
                    else if (GetComponent<PlayerInputKeyboard>())
                        playerInput.abilityReady = false;
                }
                else
                {*/
                    //if (GetComponent<PlayerInputController>())
                        //playerInputC.abilityReady = true;
                    //else if (GetComponent<PlayerInputKeyboard>())
                       // playerInput.abilityReady = true;
                }
            }
        }

        /*if (GetComponent<FlameDash>()){
        if (flameDashRef.dashTimer < 0) 
            { 
            if (GetComponent<PlayerInputController>())
                Debug.Log("Testing testing");//playerInputC.abilityReady = false;
            else if (GetComponent<PlayerInputKeyboard>())
                playerInput.abilityReady = false;
            }
        }
    }*/
    }
    public void StartingInput()
    {
        //gameObject.AddComponent<PlayerInputController>();
        playerInputInterface = gameObject.GetComponent<PlayerInputKeyboard>();
        BindNewInput(playerInputInterface);
    }
    public void ControllerInput()
    {
        BindNewInput(GetComponent<PlayerInputController>());
        menu.SetActive(false);       

    }
    public void BindNewInput(IPlayerInput newInput)
    {
        playerInputInterface.MoveInput -= movementRef.Move;
        playerInputInterface.JumpInput -= playerJumpRef.Jump;
        playerInputInterface.CameraMoveInput -= cameraControlRef.RotateCamera;
        if (GetComponent<WindJump>())
            playerInputInterface.WindJumpInput -= windJumpRef.DoubleJump;
        if (GetComponent<FlameDash>())
            playerInputInterface.FlameDashInput -= flameDashRef.Dash;
        /* (GetComponent<IceSkate>())
            playerInputInterface.IceSkateInput -= iceSkateRef.Skate;*/
        if (GetComponent<ProjectileShoot>())
        {
            playerInputInterface.SwitchProjectileInput -= projectileShootRef.SwitchProjectile;
            playerInputInterface.ShootInput -= projectileShootRef.Shoot;
        }

        playerInputInterface = newInput;

        playerInputInterface.MoveInput += movementRef.Move;
        playerInputInterface.JumpInput += playerJumpRef.Jump;
        playerInputInterface.CameraMoveInput += cameraControlRef.RotateCamera;
        if (GetComponent<WindJump>())
            playerInputInterface.WindJumpInput += windJumpRef.DoubleJump;
        if (GetComponent<FlameDash>())
            playerInputInterface.FlameDashInput += flameDashRef.Dash;
        /* (GetComponent<IceSkate>())
            playerInputInterface.IceSkateInput += iceSkateRef.Skate;*/
        if (GetComponent<ProjectileShoot>())
        { 
             playerInputInterface.SwitchProjectileInput += projectileShootRef.SwitchProjectile;
             playerInputInterface.ShootInput += projectileShootRef.Shoot;
        }

    }
    public void KeyboardInput()
    {
        BindNewInput(GetComponent<PlayerInputKeyboard>());
        menu.SetActive(false);       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            playerJumpRef.isGrounded = true;
            if (GetComponent<FlameDash>())
                flameDashRef.canDash = true;
            if (GetComponent<WindJump>())
                windJumpRef.canWindJump = true;
        }       
    }
}
