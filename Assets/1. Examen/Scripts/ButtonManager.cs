using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonManager : MonoBehaviour
{
    AlarmManager alarmManager;
    Hideouts hideOuts;
    ScoreManager scoreManager;
    SoundManager soundManager;
    Timer timer;
    
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        alarmManager = FindObjectOfType<AlarmManager>();
        hideOuts = FindObjectOfType<Hideouts>();
        scoreManager = FindObjectOfType<ScoreManager>();
        timer = FindObjectOfType<Timer>();

    }

    public void PlayMusicButton()
    {
        hideOuts.dialogueText.text = "Luister zorgvuldig naar de klanken.. welk alarm is het?";
        alarmManager.playSound = true;
        //enable alarmbutton UI 
    }
    public void ClickSound()
    {
        soundManager.Play("Click");
    }
    public void AlarmButton(GameObject other) //allows you to attach a gameobject called other
    {
        
        if (alarmManager.currentAlarm.ToString() == other.name)  //checks if current alarm matches the name of other gameobject
        {
            hideOuts.dialogueText.text = "Dit klopt!";
            scoreManager.goodPoints++;
            Debug.Log("These are the correct choices: " + scoreManager.goodPoints);
            alarmManager.GenerateAlarm();
            soundManager.Play("GoodSoundEffect");
            timer.timeValue = 180;

        }
        else
        {
            hideOuts.dialogueText.text = "Dit is niet correct.";
            scoreManager.badPoints++;
            Debug.Log("These are the wrong choices: " + scoreManager.badPoints);
            soundManager.Play("BadSoundEffect");
        }
    }

}
