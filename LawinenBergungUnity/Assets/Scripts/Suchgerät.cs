using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Suchgerät : MonoBehaviour
{
    [SerializeField] private GameObject sender;
    [SerializeField] private TextMeshProUGUI meterAnzeige;
    [SerializeField] private TextMeshProUGUI winkelAnzeige;
    [SerializeField] private GameObject player;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calcDistance();
        calcAngle();
    }
    void calcDistance(){
    
        distance = Vector3.Distance(player.transform.position,sender.transform.position);
        meterAnzeige.SetText(Math.Round(distance,1).ToString() + "m");
    }

    void calcAngle()
    {
        //set the y value to 0 to get the Angle on the x,z plane instead of the smallest angle in the room
        //ToDo : still neccessary with "SignedAngle"?
        Vector3 targetDir = sender.transform.position - this.player.transform.position;
        targetDir.y = 0;
        Vector3 playerVect = player.transform.forward;
        playerVect.y = 0;
        float angle = Vector3.SignedAngle(targetDir, playerVect, Vector3.up);
        
        winkelAnzeige.SetText(Math.Round(angle,1).ToString() + "°");
    }
}
