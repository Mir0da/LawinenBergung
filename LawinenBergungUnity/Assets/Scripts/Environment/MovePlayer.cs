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

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,-75,75),
            Mathf.Clamp(transform.position.y,1,2),
            Mathf.Clamp(transform.position.z,-75,75));
        
        if(moveX < 0)
        {
            transform.localPosition += transform.right * moveX * moveSpeed * Time.deltaTime;
        }
        if(moveX > 0){
            transform.localPosition += transform.right * moveX * moveSpeed * Time.deltaTime;
        }
        
        if(moveZ < 0){
            transform.localPosition += transform.forward * moveZ * moveSpeed * Time.deltaTime;
        }
        if(moveZ > 0){
            transform.localPosition += transform.forward * moveZ * moveSpeed * Time.deltaTime;
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
