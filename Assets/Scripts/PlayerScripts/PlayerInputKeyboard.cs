using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputKeyboard : MonoBehaviour, IPlayerInput
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
    public InputActionReference cameraAction;
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
        CameraMove();
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
        if (Input.GetKeyDown(KeyCode.Space) && JumpInput != null)
        {
            JumpInput();
        }
    }
    void Move()
    {
        if (MoveInput != null)
        {
            float movementX = Input.GetAxis("Horizontal");
            float movementZ = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(movementX, 0, movementZ);
            MoveInput(direction);
            //Debug.Log("Gaaay");
        }
    }
    void CameraMove()
    {
        if (CameraMoveInput != null)
        {
            /*float cameraX = Input.GetAxis("Mouse X");
            float cameraY = Input.GetAxis("Mouse Y");
            Vector3 direction = new Vector3(cameraX, cameraY, 0);*/
            CameraMoveInput(cameraAction);
        }
    }
    void FlameDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && abilityReady && FlameDashInput != null)
        {
            FlameDashInput();
            abilityCooldown = 3f;
        }
    }
    void WindJump()
    {
        if (Input.GetKeyDown(KeyCode.Z) && abilityReady && WindJumpInput != null)
        {
            WindJumpInput();
            Debug.Log("AIr JUmp");
            abilityCooldown = 4f;
        }
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ShootInput != null)
        {
            ShootInput();
        }
    }
    void SwitchProjectile()
    {
        if (SwitchProjectileInput != null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
                SwitchProjectileInput(true);
            else if (Input.GetKeyDown(KeyCode.Alpha1))
                SwitchProjectileInput(false);
        }
    }
}
