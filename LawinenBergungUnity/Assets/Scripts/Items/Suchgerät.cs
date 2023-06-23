using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Suchgerät : MonoBehaviour
{
    [SerializeField] private GameObject sender;
    [SerializeField] private TextMeshProUGUI meterAnzeige;
    [SerializeField] private TextMeshProUGUI winkelAnzeige;
    [SerializeField] private GameObject player;
    [SerializeField] private Image arrowFarLeft;
    [SerializeField] private Image arrowLeft;
    [SerializeField] private Image arrowMid;
    [SerializeField] private Image arrowRight;
    [SerializeField] private Image arrowFarRight;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        disableAllArrows();
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
        
        displayAngleAsArrow(angle);
        
        //winkelAnzeige.SetText(Math.Round(angle,1).ToString() + "°");
    }

    private void displayAngleAsArrow(float angle)
    {
        double roundedAngel = Math.Round(angle, 1);

        if (roundedAngel <= 10 && roundedAngel >= -10)
        {
            disableAllArrows();
            arrowMid.gameObject.SetActive(true);
        }
        else if (roundedAngel > 10 && roundedAngel <= 45)
        {
            disableAllArrows();
            arrowLeft.gameObject.SetActive(true);
        }
        else if (roundedAngel >= -45 && roundedAngel < -10)
        {
            disableAllArrows(); 
            arrowRight.gameObject.SetActive(true);
        }
        else if (roundedAngel > 45 && roundedAngel < 180)
        {
            disableAllArrows();
            arrowFarLeft.gameObject.SetActive(true);
        }
        else if (roundedAngel < -45 && roundedAngel >= -180)
        {
            disableAllArrows();
            arrowFarRight.gameObject.SetActive(true);
            
        }

    }

    private void disableAllArrows()
    {
        arrowMid.gameObject.SetActive(false);
        arrowFarRight.gameObject.SetActive(false);
        arrowFarLeft.gameObject.SetActive(false);
        arrowRight.gameObject.SetActive(false);
        arrowLeft.gameObject.SetActive(false);
    }
}
