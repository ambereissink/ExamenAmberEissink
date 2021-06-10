using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    
    SoundManager soundManager;
    bool buttonOn;
    int lastGoodPoints = 0;
    int lastBadPoints = 0;
    public int goodPoints = 0;
    public int badPoints = 0;
    public TMP_Text goodPointsText;
    public TMP_Text badPointsText;
    Hideout hideOuts;
    Button[] alarmButtons;
    public GameObject certificatePanel;
    public GameObject alarmBellen;
    public GameObject alarmQuestion;
    public GameObject shelterQuestion;
    public TMP_Text[] alarmText;
    public GameObject tutorialPanel;
    public bool tutorialOn = true;
    bool textOn;
    public bool certificateOn;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        
        hideOuts = FindObjectOfType<Hideout>();
        alarmButtons = alarmBellen.GetComponentsInChildren<Button>();
        alarmText = alarmBellen.GetComponentsInChildren<TMP_Text>();
        buttonOn = true;
        textOn = false;
        tutorialPanel.SetActive(tutorialOn);
        certificatePanel.SetActive(false);
        shelterQuestion.SetActive(false);
        alarmQuestion.SetActive(true);
        //goodPoints = 30;

    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.K)) goodPoints++;

        if (lastGoodPoints != goodPoints)
        {
            NextQuestion();
            lastGoodPoints = goodPoints;
        }
        if(lastBadPoints != badPoints)
        {
            lastBadPoints = badPoints;
            soundManager.Play("BadSoundEffect");
        }
        goodPointsText.text = goodPoints.ToString();
        badPointsText.text = badPoints.ToString();
    }
    public void NextQuestion() 
    {
        FindObjectOfType<PlayerLocation>()?.SetRandomPosition();
        FindObjectOfType<AlarmManager>()?.GenerateAlarm();
        FindObjectOfType<AlarmManager>()?.FullAudioReset();
        soundManager.Play("GoodSoundEffect");
        if (goodPoints >= 5)
        {
            
            //disable this question object UI
            alarmQuestion.SetActive(false);
            //enable next question object UI
            shelterQuestion.SetActive(true);
            //disable alarmbellen buttons but keep appearance
            DisableButtons();
            string newText = "Vragen compleet, door naar het volgende onderdeel! Klik opnieuw op de alarmknop en vind U locatie."; 
            if(newText != hideOuts.dialogueText.text) soundManager.Play("Writing");
            hideOuts.dialogueText.text = newText;
            
            FindObjectOfType<FindRoute>().CreateNewCorrectHideout();
        }

        else
        {
            buttonOn = true;
        }
         
        if(goodPoints >= 15)
        {
            
            foreach (TMP_Text textChild in alarmText)
            {
                textOn = false;
                textChild.gameObject.SetActive(textOn);
                Debug.Log("de text is off");
                hideOuts.dialogueText.text = "En dan nu, zonder de alarmnummers!";
                soundManager.Play("Writing");

            }
        }
        if (goodPoints >= 30)
        {
            //geef certificaat
            certificatePanel.SetActive(true);
            certificateOn = true;
            //stop timer
        }
        else
        {
            certificatePanel.SetActive(false);
        }
        if (goodPoints + badPoints >= 50)
        {
            //if the good points and badpoints together are 50 or more, send to failscene
            SceneManager.LoadScene("FailScene");
        }
    }
    void DisableButtons()
    {
        foreach (Button child in alarmButtons)
        {
            child.interactable = buttonOn;
            buttonOn = false;
        }
    }


}
