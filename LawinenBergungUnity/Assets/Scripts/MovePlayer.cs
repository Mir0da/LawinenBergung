using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.01f;
    private AudioSource audioSrc;


    private float moveX;
    private float moveZ;
    private bool isMoving;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

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
        if (moveZ != 0 || moveX != 0)
        {
            isMoving = true;
        }
        else
            isMoving = false;

        playFootsteps();
    }

    private void playFootsteps()
    {
        if (isMoving)
        {
            if (audioSrc.isPlaying == false)
            {

                audioSrc.Play();
            }
        }
        else { 
            audioSrc.Stop();
        }
    }
}
