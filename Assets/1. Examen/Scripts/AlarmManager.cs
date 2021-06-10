using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class AlarmManager : MonoBehaviour
{
    int arrayCounter = 0;
    int[] Alarms = new int[3];
    public int currentAlarm;
    public int first;
    public int second = 1;
    public int third;
    float resetTimer = 1;
    float timer = 0;
    int counter = 0;
    public bool playSound = false;
    // in this script we have to write a function that randomizes which alarm is played
    // in this script we connect the randomized alarm to the correct button 

    // Start is called before the first frame update
    void Start()
    {
        Alarms[1] = 1;
        GenerateAlarm();
        //PlayAlarm();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSound)
        {
            //increments timer
            timer += Time.deltaTime;
            if (timer >= resetTimer)
            {
                timer = 0;
                counter++;
                if (counter <= Alarms[arrayCounter])
                //if current counter is smaller or equal to the amount of sounds to play then play sound
                {
                    if (arrayCounter != 1)
                    { //if not middle sound play horn else play bell
                        FindObjectOfType<SoundManager>().Play("Horn");
                    }
                    else
                    {
                        FindObjectOfType<SoundManager>().Play("Bell");
                    }
                    Debug.Log("Played this sound");
                }
                else //if not go to the next step in the array and reset the timer
                {
                    ResetAudio();
                }
            }
        }
    }

    public void FullAudioReset()
    {
        arrayCounter = 3;
        ResetAudio();
    }

    public void ResetAudio()
    {
        arrayCounter++;
        counter = 0;
        timer = 0;
        if (arrayCounter >= 3) //if array counter is too big, disable sound
        {
            playSound = false;
            arrayCounter = 0;
        }
    }

    public void GenerateAlarm()
    {
        //generates random numbers for the first and third spot, the middle staying the same
        System.Random rnd = new System.Random();
        Alarms[0] = rnd.Next(1, 4);  // creates a number between 1 and 3
        Alarms[2] = rnd.Next(1, 4);

        //adding the two randomized number plus the one static in the middle
        currentAlarm = int.Parse(Alarms[0].ToString() + Alarms[1] + Alarms[2].ToString());
        Debug.Log(currentAlarm);

    }
    void PlayAlarm()
    {
        playSound = true;
    }

}


   



