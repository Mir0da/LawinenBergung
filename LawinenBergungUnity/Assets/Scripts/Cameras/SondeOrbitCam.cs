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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
