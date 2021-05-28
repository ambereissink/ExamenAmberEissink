using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 180;
    public TMP_Text timerText;
    ScoreManager scoreManager;
    Hideouts hideOuts;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        hideOuts = FindObjectOfType<Hideouts>();
    }
    void Update()
    {
        CountDown();
        DisplayTime(timeValue);
    }
    void CountDown()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 180;
            //say something about how the player failed
            hideOuts.dialogueText.text = "De tijd is op! Klik op het geluids-icoon voor een nieuw alarm.";
            //generate new alarm
            //add one bad point
            //reset timer
            //watch out cus its doing some weird shit rn still counting from 180 regardless if i put it to 10
        }
    }
     void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
