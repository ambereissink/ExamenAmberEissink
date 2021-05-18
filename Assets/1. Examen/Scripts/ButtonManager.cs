using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        AlarmManager alarmManager = FindObjectOfType<AlarmManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusicButton()
    {
        //test
        FindObjectOfType<SoundManager>().Play("Bell");
        //play sound for random scenario
        //see alarmmanager
    }
    public void AlarmButton()
    {
       
    }

}
