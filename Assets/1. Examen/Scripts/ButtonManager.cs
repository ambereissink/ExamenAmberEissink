using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    AlarmManager alarmManager;
    Hideout hideOuts;
    ScoreManager scoreManager;
    SoundManager soundManager;
    Timer timer;
    public GameObject infoPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        infoPanel.SetActive(false);
        soundManager = FindObjectOfType<SoundManager>();
        alarmManager = FindObjectOfType<AlarmManager>();
        hideOuts = FindObjectOfType<Hideout>();
        scoreManager = FindObjectOfType<ScoreManager>();
        timer = FindObjectOfType<Timer>();

    }

    public void PlayMusicButton()
    {
        hideOuts.dialogueText.text = "Luister zorgvuldig naar de klanken.. welk alarm is het?";
        soundManager.Play("Writing");
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
            hideOuts.dialogueText.text = "Dit klopt! Klik weer op de alarmknop voor het nieuwe alarm.";
            soundManager.Play("Writing");
            scoreManager.goodPoints++;
            Debug.Log("These are the correct choices: " + scoreManager.goodPoints);
            
            soundManager.Play("GoodSoundEffect");
            timer.timeValue = 180;
            alarmManager.FullAudioReset();
            //werkt niet want dan speelt hij de eerste van de volgende niet af
        }
        else
        {
            hideOuts.dialogueText.text = "Dit is niet correct.";
            soundManager.Play("Writing");
            scoreManager.badPoints++;
            Debug.Log("These are the wrong choices: " + scoreManager.badPoints);
            soundManager.Play("BadSoundEffect");
        }
    }
    public void InfoButtonOpen()
    {
        infoPanel.SetActive(true);
    }
    public void InfoButtonClose()
    {
        infoPanel.SetActive(false);
    }
    public void ChangeSceneStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ChangeSceneSTrainer()
    {
        SceneManager.LoadScene("TrainerScene");
    }
    public void ChangeSceneMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void Quit()
    {
        Application.Quit();
    }

}
