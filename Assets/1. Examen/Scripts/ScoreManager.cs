using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    SoundManager soundManager;
    bool buttonOn;
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
        certificatePanel.SetActive(false);
        shelterQuestion.SetActive(false);
        alarmQuestion.SetActive(true);
        //goodPoints = 30;

    }

    // Update is called once per frame
    void Update()
    {
        NextQuestion();
        goodPointsText.text = goodPoints.ToString();
        badPointsText.text = badPoints.ToString();
    }
    void NextQuestion() 
    {
        if (goodPoints >= 5)
        {
            //disable this question object UI
            alarmQuestion.SetActive(false);
            //enable next question object UI
            shelterQuestion.SetActive(true);
            //disable alarmbellen buttons but keep appearance
            DisableButtons();
            hideOuts.dialogueText.text = "Vragen compleet, door naar het volgende onderdeel! Klik opnieuw op de alarmknop en vind U locatie.";
            soundManager.Play("Writing");
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
            
            //stop timer
        }
        else
        {
            certificatePanel.SetActive(false);
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
