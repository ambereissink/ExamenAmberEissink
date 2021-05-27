using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonManager : MonoBehaviour
{
    AlarmManager alarmManager;
    Hideouts hideOuts;
    ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        alarmManager = FindObjectOfType<AlarmManager>();
        hideOuts = FindObjectOfType<Hideouts>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusicButton()
    {
        hideOuts.dialogueText.text = "Luister zorgvuldig naar de klanken.. welk alarm is het?";
        alarmManager.playSound = true;
        //enable alarmbutton UI 
    }
    public void AlarmButton()
    {

    }
    public void ClickSound()
    {
        FindObjectOfType<SoundManager>().Play("Click");
    }
    public void AlarmQuestion(GameObject other) //allows you to attach a gameobject called other
    {
        
        if (alarmManager.currentAlarm.ToString() == other.name)  //checks if current alarm matches the name of other gameobject
        {
            hideOuts.dialogueText.text = "Dit klopt!";
            scoreManager.goodPoints++;
            Debug.Log("These are the correct choices: " + scoreManager.goodPoints);
        }
        else
        {
            hideOuts.dialogueText.text = "Dit is niet correct.";
            scoreManager.badPoints++;
            Debug.Log("These are the wrong choices: " + scoreManager.badPoints);
        }
    }

}
