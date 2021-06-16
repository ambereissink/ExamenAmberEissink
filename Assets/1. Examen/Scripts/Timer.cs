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
    Hideout hideOuts;
    AlarmManager alarmManager;
    SoundManager soundManager;

    private void Start()
    {
        alarmManager = FindObjectOfType<AlarmManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        hideOuts = FindObjectOfType<Hideout>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Update()
    {
        if (scoreManager.certificateOn == true || scoreManager.tutorialOn == false)  //makes it so the timer doesn't go off when tutorial&certificaat is enabled
        { 
        CountDown();
        DisplayTime(timeValue);
        }
    }
    void CountDown() //the actual timer function
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            
            //reset timer
            timeValue = 180;
            //say something about how the player failed
            hideOuts.dialogueText.text = "De tijd is op! Klik op het geluids-icoon voor een nieuw alarm.";
            soundManager.Play("Writing");
            //generate new alarm
            scoreManager.NextQuestion();
            //add one bad point
            scoreManager.badPoints++;
            soundManager.Play("BadSoundEffect");
            
        }
    }
     void DisplayTime(float timeToDisplay) //function to display time
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); //displays minutes and seconds
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
