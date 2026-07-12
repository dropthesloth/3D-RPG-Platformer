using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;
using System;

public class CameraController : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField]CinemachineFreeLook playerCamera;
    [SerializeField] CinemachineInputProvider cameraInput;
    InputAction action;
    [SerializeField]PlayerController playerControllerRef;
    CameraControls controls;    
    // Start is called before the first frame update
    void Start()
    {
        controls = new CameraControls();
        controls.Mouse.Enable();
        controls.Controller.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(playerControllerRef.playerInputInterface == gameObject.transform.GetComponent<PlayerInputController>())
        {
            playerCamera.m_XAxis.m_InputAxisName = "RStickX";
            playerCamera.m_YAxis.m_InputAxisName = "RStickY";
        }
        else if ( ||playerControllerRef.playerInputInterface == gameObject.transform.GetComponent<PlayerInputKeyboard>() && (Input.GetMouseButton(0)))
        {

        }*/
    }
    public void RotateCamera(InputActionReference camControl /*Vector3 cameraRotation*/)
    {
        if (playerControllerRef.playerInputInterface is PlayerInputController)
        {
            cameraInput.XYAxis = camControl;
            cameraInput.XYAxis.name = "Controller/ControllerLook";
            /*playerCamera.m_XAxis.m_InputAxisName = "RStickX";
            playerCamera.m_YAxis.m_InputAxisName = "RStickY";        
            playerCamera.m_XAxis.Value = Input.GetAxis("RStickX");
            playerCamera.m_YAxis.Value = Input.GetAxis("RStickY");
            Debug.Log("Current X Position = " + Input.GetAxis("RStickX"));
            Debug.Log("Current Y Position = " + Input.GetAxis("RStickY"));
            if (Input.GetAxis("RStickX") >= 0.1f || Input.GetAxis("RStickX") <= -0.1f)
                Debug.Log("cool");
            if (Input.GetAxis("RStickY") >= 0.1f || Input.GetAxis("RStickY") <= -0.1f)
                Debug.Log("neat");*/
            playerCamera.m_YAxis.m_MaxSpeed = 10;
            playerCamera.m_XAxis.m_MaxSpeed = 300;
        }
        else if (playerControllerRef.playerInputInterface is PlayerInputKeyboard)
        {
            Debug.Log("gaming");
            cameraInput.XYAxis = camControl;
            /*playerCamera.m_XAxis.m_InputAxisName = "Mouse X";
            playerCamera.m_YAxis.m_InputAxisName = "Mouse Y";*/
            // cameraInput.XYAxis.name = "Mouse/MouseLook";
            if (controls.Mouse.MouseClick.IsPressed())
            {
                Debug.Log("extreme gaming");
                playerCamera.m_YAxis.m_MaxSpeed = 2;
                playerCamera.m_XAxis.m_MaxSpeed = 200;
            }
            else
            {
                Debug.Log("fdsfsdfsd");
                playerCamera.m_YAxis.m_MaxSpeed = 0;
                playerCamera.m_XAxis.m_MaxSpeed = 0;
            }
        }
    }
}
