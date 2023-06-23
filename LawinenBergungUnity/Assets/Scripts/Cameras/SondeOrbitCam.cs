using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SondeOrbitCam : MonoBehaviour
{
    private CinemachineFreeLook freeLookCamera;

    private void Awake()
    {
        freeLookCamera = GetComponent<CinemachineFreeLook>();
    }

    private void Start()
    {
        freeLookCamera.m_XAxis.m_InputAxisName = "";
        freeLookCamera.m_YAxis.m_InputAxisName = "";
    }
    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            freeLookCamera.m_XAxis.m_InputAxisValue = Input.GetAxis("Mouse X");
            freeLookCamera.m_YAxis.m_InputAxisValue = Input.GetAxis("Mouse Y");
        }
        else
        {
            freeLookCamera.m_XAxis.m_InputAxisValue = 0;
            freeLookCamera.m_YAxis.m_InputAxisValue = 0;
        }
    }

    public void freeMouse()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
