using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FirstPersonCam : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform camholder;
    [SerializeField] private Transform player;
    private float yaw;
    private float pitch;
    
    // Start is called before the first frame update
    void Start()
    {
        //Switch if in Inventory
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    private void Update()
    {
        //get mouse Input
         yaw = Input.GetAxis("Mouse X");
         pitch = Mathf.Clamp(Input.GetAxis("Mouse Y"), -90f, 90f);
        
        //Rotate player and its Orientation/Cam
        Vector3 rotateValue = new Vector3(pitch, -yaw, 0) * rotationSpeed;
        camholder.transform.eulerAngles -= rotateValue;
        Vector3 rotatePlayer = new Vector3(0, -yaw, 0) * rotationSpeed;
        player.transform.eulerAngles -= rotatePlayer;
    }
}