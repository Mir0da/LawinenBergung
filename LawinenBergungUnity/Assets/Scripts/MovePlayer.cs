using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.01f;
    
    private float moveX;
    private float moveZ;
    
   

    // Update is called once per frame
    void Update()
    {
       
        //get Input
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        
        if(moveX < 0)
        {
            transform.localPosition += transform.right * moveX * moveSpeed;
        }
        if(moveX > 0){
            transform.localPosition += transform.right * moveX * moveSpeed;
        }
        
        if(moveZ < 0){
            transform.localPosition += transform.forward * moveZ * moveSpeed;
        }
        if(moveZ > 0){
            transform.localPosition += transform.forward * moveZ * moveSpeed;
        }
    }
    
}
