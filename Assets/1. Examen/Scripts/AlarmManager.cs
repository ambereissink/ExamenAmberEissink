using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlarmManager : MonoBehaviour
{
    public int currentAlarm;

    // in this script we have to write a function that randomizes which alarm is played
    // in this script we connect the randomized alarm to the correct button 

    // Start is called before the first frame update
    void Start()
    {
        //generates random numbers for the first and third spot, the middle staying the same
        System.Random rnd = new System.Random();
        int first = rnd.Next(1, 3);  // creates a number between 1 and 3
        int third = rnd.Next(1, 3);

        //adding the two randomized number plus the one static in the middle
        int currentAlarm = int.Parse(first.ToString() + 1 + third.ToString());
        Debug.Log(currentAlarm);

        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

   
}


