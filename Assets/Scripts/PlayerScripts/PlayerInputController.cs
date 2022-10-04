using UnityEngine;

public class PlayerInputController : MonoBehaviour, IPlayerInput
{
    //public PlayerJump jumpRef;
    public bool abilityReady;
    public float abilityCooldown;
    public event PlayerActionDirection MoveInput = delegate { };
    public event PlayerActionDirection CameraMoveInput = delegate { };
    public event PlayerAction JumpInput = delegate { };
    public event PlayerAction ShootInput = delegate { };
    public event PlayerActionSwitch SwitchProjectileInput = delegate { };
    public event PlayerAction WindJumpInput = delegate { };
    public event PlayerAction FlameDashInput = delegate { };
    // Start is called before the first frame update
    void Awake()
    {

        abilityReady = false;
        abilityCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveInput != null)
        {
            float movementX = Input.GetAxis("Horizontal");
            float movementY = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(movementX, 0, movementY);
            MoveInput(direction);
        }
        if(CameraMoveInput != null)
        {
            float cameraX = Input.GetAxis("RStickX");
            float cameraY = Input.GetAxis("RStickY");
            Vector3 direction = new Vector3(cameraX, cameraY, 0);
            CameraMoveInput(direction);
        }
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.G) && JumpInput != null)
        {
            JumpInput();
        }
        if (Input.GetButtonDown("Ability") && abilityReady && WindJumpInput != null)
        {
            WindJumpInput();
            Debug.Log("AIr JUmp");
            abilityCooldown = 4f;
        }
        if (Input.GetButtonDown("Ability2") && abilityReady && FlameDashInput != null)
        {
            FlameDashInput();
            abilityCooldown = 3f;
        }
        if (Input.GetButtonDown("Fire") && ShootInput != null)
        {
            Debug.Log("Shoot!");
            ShootInput();
        }
        if (SwitchProjectileInput != null)
        {
            if (Input.GetAxis("Switch") > 0)
                SwitchProjectileInput(true);
            else if (Input.GetAxis("Switch") < 0)
                SwitchProjectileInput(false);
        }
    }
}

