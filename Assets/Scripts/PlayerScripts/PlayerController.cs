using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [HideInInspector] public bool hasDoubleJump;
    [SerializeField] PlayerJump playerJumpRef;
    //PlayerInputKeyboard playerInput;
    // PlayerInputController playerInputC;
    [SerializeField] PlayerInputKeyboard inputRef;
    //[HideInInspector] public IPlayerInput playerInputInterface;
    [HideInInspector] public WindJump windJumpRef;
    [HideInInspector] public FlameDash flameDashRef;
    public ProjectileShoot projectileShootRef;
    [SerializeField] GameObject menu;
    Movement movementRef;
    //CameraController cameraControlRef;
    private void Awake()
    {
        //playerInput = GetComponent<PlayerInputKeyboard>();
        //playerInputInterface = GetComponent<IPlayerInput>();
        movementRef = GetComponent<Movement>();
        // cameraControlRef = GetComponent<CameraController>();
        //playerInput.MoveInput += movementRef.Move;
        //playerInput.JumpInput += playerJumpRef.Jump;

        //StartingInput();
        //KeyboardInput();
    }

    // Update is called once per frame
    void Update()
    {
        movementRef.dir = new Vector3(inputRef.MoveInput.action.ReadValue<Vector2>().x,
                                        0, inputRef.MoveInput.action.ReadValue<Vector2>().y);
    }
    private void FixedUpdate()
    {
        if (movementRef.dir != Vector3.zero)
            movementRef.Move(movementRef.dir);
    }
    private void OnEnable()
    {
        inputRef.MoveInput.action.started += Accelerate;
        inputRef.MoveInput.action.canceled += Decelerate;
        inputRef.JumpInput.action.performed += Jump;
        inputRef.ShootInput.action.performed += Shoot;
        inputRef.SwitchProjectileInput.action.performed += SwitchProjectile;
        if (windJumpRef != null)
            inputRef.WindJumpInput.action.performed += DoubleJump;
        if (flameDashRef != null)
            inputRef.FlameDashInput.action.performed += Dash;
        // playerInputInterface.MoveInput
    }
    private void OnDisable()
    {
        inputRef.MoveInput.action.started -= Accelerate;
        inputRef.MoveInput.action.canceled -= Decelerate;
        inputRef.JumpInput.action.performed -= Jump;
        inputRef.ShootInput.action.performed -= Shoot;
        inputRef.SwitchProjectileInput.action.performed -= SwitchProjectile;
        if (windJumpRef != null)
            inputRef.WindJumpInput.action.performed -= DoubleJump;
        if (flameDashRef != null)
            inputRef.FlameDashInput.action.performed -= Dash;
    }
    /*public void StartingInput()
    {
        //gameObject.AddComponent<PlayerInputController>();
        playerInputInterface = gameObject.GetComponent<PlayerInputKeyboard>();
        BindNewInput(playerInputInterface);
    }
    public void ControllerInput()
    {
        BindNewInput(GetComponent<PlayerInputController>());
        menu.SetActive(false);       

    }*/
    /*void Move(InputAction.CallbackContext context)
    {
        Vector3 direction = new Vector3(context.action.ReadValue<Vector2>().x,
                                        0, context.action.ReadValue<Vector2>().y);
        movementRef.Move(direction);
    }*/
    void Accelerate(InputAction.CallbackContext context)
    {
        Debug.Log("fuckin");
        Vector3 direction = new Vector3(context.action.ReadValue<Vector2>().x,
                                        0, context.action.ReadValue<Vector2>().y);
        StartCoroutine(movementRef.Accelerate(direction));
    }
    void Decelerate(InputAction.CallbackContext context)
    {
        Debug.Log("fuckin dick");
        Vector3 direction = new Vector3(context.action.ReadValue<Vector2>().x,
                                        0, context.action.ReadValue<Vector2>().y);
        StartCoroutine(movementRef.Decelerate(direction));
    }

    void Jump(InputAction.CallbackContext context)
    {
        playerJumpRef.Jump();
    }
    void DoubleJump(InputAction.CallbackContext context)
    {
        if (windJumpRef != null)
            windJumpRef.DoubleJump();
    }
    void Dash(InputAction.CallbackContext context)
    {
        if (flameDashRef != null)
            flameDashRef.Dash();
    }
    void SwitchProjectile(InputAction.CallbackContext context)
    {
        if (projectileShootRef.projectiles.Count > 1)
            projectileShootRef.SwitchProjectile(context.ReadValue<float>() > 0);
    }
    void Shoot(InputAction.CallbackContext context)
    {
        projectileShootRef.Shoot();
    }
    /*public void BindNewInput(IPlayerInput newInput)
    {
        playerInputInterface.MoveInput -= movementRef.Move;
        playerInputInterface.JumpInput -= playerJumpRef.Jump;
        // playerInputInterface.CameraMoveInput -= cameraControlRef.RotateCamera;
        if (GetComponent<WindJump>())
            playerInputInterface.WindJumpInput -= windJumpRef.DoubleJump;
        if (GetComponent<FlameDash>())
            playerInputInterface.FlameDashInput -= flameDashRef.Dash;
         (GetComponent<IceSkate>())
            playerInputInterface.IceSkateInput -= iceSkateRef.Skate;
        if (GetComponent<ProjectileShoot>())
        {
            playerInputInterface.SwitchProjectileInput -= projectileShootRef.SwitchProjectile;
            playerInputInterface.ShootInput -= projectileShootRef.Shoot;
        }

        playerInputInterface = newInput;

        playerInputInterface.MoveInput += movementRef.Move;
        playerInputInterface.JumpInput += playerJumpRef.Jump;
        //playerInputInterface.CameraMoveInput += cameraControlRef.RotateCamera;
        if (GetComponent<WindJump>())
            playerInputInterface.WindJumpInput += windJumpRef.DoubleJump;
        if (GetComponent<FlameDash>())
            playerInputInterface.FlameDashInput += flameDashRef.Dash;
         (GetComponent<IceSkate>())
            playerInputInterface.IceSkateInput += iceSkateRef.Skate;
        if (GetComponent<ProjectileShoot>())
        {
            playerInputInterface.SwitchProjectileInput += projectileShootRef.SwitchProjectile;
            playerInputInterface.ShootInput += projectileShootRef.Shoot;
        }

    }*/
    /*public void KeyboardInput()
    {
        BindNewInput(GetComponent<PlayerInputKeyboard>());
        menu.SetActive(false);       
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (GetComponent<FlameDash>())
        {
            Debug.Log("Guh?");
            flameDashRef.canDash = true;
        }
        if (GetComponent<WindJump>())
            windJumpRef.canWindJump = true;
    }
}
