using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField]CinemachineFreeLook playerCamera;
    [SerializeField]PlayerController playerControllerRef;
    // Start is called before the first frame update
    void Start()
    {
        
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
    public void RotateCamera(Vector3 cameraRotation)
    {
        if (playerControllerRef.playerInputInterface == gameObject.transform.GetComponent<PlayerInputController>())
        {
            playerCamera.m_XAxis.m_InputAxisName = "RStickX";
            playerCamera.m_YAxis.m_InputAxisName = "RStickY";
            playerCamera.m_YAxis.m_MaxSpeed = 10;
            playerCamera.m_XAxis.m_MaxSpeed = 300;
        }
        else if (playerControllerRef.playerInputInterface == gameObject.transform.GetComponent<PlayerInputKeyboard>())
        {
            Debug.Log("gaming");
            playerCamera.m_XAxis.m_InputAxisName = "Mouse X";
            playerCamera.m_YAxis.m_InputAxisName = "Mouse Y";
            if (Input.GetMouseButton(0))
            {
                Debug.Log("extreme gaming");
                playerCamera.m_YAxis.m_MaxSpeed = 20;
                playerCamera.m_XAxis.m_MaxSpeed = 300;
            }
            else
            {
                playerCamera.m_YAxis.m_MaxSpeed = 0;
                playerCamera.m_XAxis.m_MaxSpeed = 0;
            }
        }
    }
}
