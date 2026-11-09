//using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PlayerInputKeyboard : MonoBehaviour
{
    //public PlayerJump jumpRef;
     public bool abilityReady;
    public float abilityCooldown;
    [SerializeField]TextMeshProUGUI abilityCooldownText;
    public InputActionReference MoveInput;
    public InputActionReference JumpInput;
    public InputActionReference ShootInput;
    public InputActionReference SwitchProjectileInput;
    public InputActionReference WindJumpInput;
    public InputActionReference FlameDashInput;
    // public event PlayerActionDirection MoveInput = delegate { };
    //public event PlayerActionCameraDirection CameraMoveInput = delegate { };
    // public event PlayerAction JumpInput = delegate { };
    //public event PlayerAction ShootInput = delegate { };
    // public event PlayerActionSwitch SwitchProjectileInput = delegate { };
    //public event PlayerAction WindJumpInput = delegate { };
    //public event PlayerAction FlameDashInput = delegate { };

    // public InputActionReference cameraAction;
    [SerializeField]Image coolDownSlider;
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
            coolDownSlider.fillAmount = 1 - (abilityCooldown / 2);
            abilityCooldownText.text = abilityCooldown.ToString("F1");
            abilityReady = false;
        }
        else if (abilityCooldown <= 0 && !abilityReady)
        {
            coolDownSlider.fillAmount = 1;
            abilityReady = true;
            abilityCooldownText.text = "Ready!";
        }
        /*if (Input.GetKeyDown(KeyCode.X) && abilityReady && IceSkateInput != null)
        {
            IceSkateInput();
            abilityCooldown = 10f;
        }*/
    }
}
