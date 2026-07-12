//using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputController : MonoBehaviour, IPlayerInput
{
    //public PlayerJump jumpRef;
    public bool abilityReady;
    public float abilityCooldown;
    public event PlayerActionDirection MoveInput = delegate { };
    public event PlayerActionCameraDirection CameraMoveInput = delegate { };
    public event PlayerAction JumpInput = delegate { };
    public event PlayerAction ShootInput = delegate { };
    public event PlayerActionSwitch SwitchProjectileInput = delegate { };
    public event PlayerAction WindJumpInput = delegate { };
    public event PlayerAction FlameDashInput = delegate { };
    //public InputActionReference cameraAction;
    // Start is called before the first frame update
    void Awake()
    {
        abilityReady = false;
        abilityCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (abilityCooldown > 0)
        {
            abilityCooldown -= Time.deltaTime;
            abilityReady = false;
        }
        else if (abilityCooldown <= 0 && !abilityReady)
            abilityReady = true;
        Jump();
        Move();
        //CameraMove();
        FlameDash();
        WindJump();
        Shoot();
        SwitchProjectile();
        /*if (Input.GetKeyDown(KeyCode.X) && abilityReady && IceSkateInput != null)
        {
            IceSkateInput();
            abilityCooldown = 10f;
        }*/
        
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.G) && JumpInput != null)
        {
            JumpInput();
        }
    }
    void Move()
    {
        if (MoveInput != null)
        {
            float movementX = Input.GetAxis("Horizontal");
            float movementY = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(movementX, 0, movementY);
            MoveInput(direction);
            //Debug.Log("Bitch");
        }
    }
    /*void CameraMove()
    {
        if (CameraMoveInput != null)
        {
            /*float cameraX = Input.GetAxis("RStickX");
            float cameraY = Input.GetAxis("RStickY");
            Vector3 direction = new Vector3(cameraX, cameraY, 0);
            CameraMoveInput(cameraAction);
        }
    }*/
    void FlameDash()
    {
        if (Input.GetButtonDown("Ability2") && abilityReady && FlameDashInput != null)
        {
            FlameDashInput();
            abilityCooldown = 3f;
        }
    }
    void WindJump()
    {
        if (Input.GetButtonDown("Ability") && abilityReady && WindJumpInput != null)
        {
            WindJumpInput();
            Debug.Log("AIr JUmp");
            abilityCooldown = 4f;
        }
    }
    void Shoot()
    {
        if (Input.GetButtonDown("Fire") && ShootInput != null)
        {
            Debug.Log("Shoot!");
            ShootInput();
        }
    }
    void SwitchProjectile()
    {
        if (SwitchProjectileInput != null)
        {
            if (Input.GetAxis("Switch") > 0)
                SwitchProjectileInput(true);
            else if (Input.GetAxis("Switch") < 0)
                SwitchProjectileInput(false);
        }
    }
}

