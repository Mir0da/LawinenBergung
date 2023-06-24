using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shovel : MonoBehaviour
{

    [SerializeField] private GameObject player;

    private void Awake()
    {
    }

    private void Update()
    {
        
    }

    public void takeShovel()
    {
        transform.parent.parent = player.transform;
        
        //translate shovel to a better position
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float attachDistance = 4;
        
        Vector3 attachPos = playerPos + playerDirection*attachDistance;
        attachPos.x += 2;
        attachPos.y -= 2;
        transform.parent.position = attachPos;
        transform.rotation = playerRotation;
        //face the thing towards the player
        transform.rotation *= Quaternion.Euler(0, 180, 0);
        Debug.Log("Shovel Equipped!");
    }

}