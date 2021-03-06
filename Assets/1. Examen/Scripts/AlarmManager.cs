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
        Alarms[1] = 1;//middle alarm is always 1
        GenerateAlarm();
        //PlayAlarm();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSound && currentAlarm != 0)
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
        else if (playSound && currentAlarm == 0) //generates unique alarm that goes 4x10 tones
        {
            timer += Time.deltaTime;
            if (timer >= resetTimer) 
            {
                counter++;
                timer = 0;
                FindObjectOfType<SoundManager>().Play("Horn");
                if (counter >= 4) //if amount of horns played is bigger than 4, set the timer to a negative value
                {
                    counter = 0;
                    timer -= resetTimer;
                    arrayCounter++;
                }
                if(arrayCounter >= 10) //if i played 10 times 4 horns, reset audio
                {
                    FullAudioReset();
                }
              
            }
        }
    }

    public void FullAudioReset() //fully resets audio
    {
        arrayCounter = 3;
        ResetAudio();
    }

    public void ResetAudio() //soft reset audio
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
        

        if (rnd.Next(0, 10) == 0) //makes it so the unique alarm has the same chance of appearing as the randomly generated one
        {
            currentAlarm = 0;
        }
        else
        {
            Alarms[0] = rnd.Next(1, 4);  // creates a number between 1 and 3
            Alarms[2] = rnd.Next(1, 4);
            currentAlarm = int.Parse(Alarms[0].ToString() + Alarms[1] + Alarms[2].ToString());
        }


        //adding the two randomized number plus the one static in the middle
        
        Debug.Log(currentAlarm);

    }
    void PlayAlarm()
    {
        playSound = true;
    }

}


   



