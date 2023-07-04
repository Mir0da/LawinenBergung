using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeLeft;[SerializeField] private TextMeshProUGUI timerLabel;
    private bool timerOn = false;

    

    private void Start()
    {
        timerOn = true;
        timeLeft *= 60;
    }

   
    private void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                timeLeft = 0;
                timerOn = false;
            }
        }
    }

    private void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minues = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        
        
        timerLabel.SetText("Zeit: " + string.Format("{0:00}:{1:00}", minues, seconds));
    }

    public void reduceTime(float time)
    {
        time *= 60;
        timeLeft -= time; 
    }
}
