using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    bool buttonOn;
    public int goodPoints = 0;
    public int badPoints = 0;
    public TMP_Text goodPointsText;
    public TMP_Text badPointsText;
    Hideouts hideOuts;
    Button[] alarmButtons;
    public GameObject alarmBellen;
    public GameObject alarmQuestion;
    public GameObject shelterQuestion;
    // Start is called before the first frame update
    void Start()
    {
        hideOuts = FindObjectOfType<Hideouts>();
        alarmButtons = alarmBellen.GetComponentsInChildren<Button>();
        buttonOn = true;
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
            hideOuts.dialogueText.text = "Vragen compleet, door naar het volgende onderdeel! Klik opnieuw op de alarmknop.";
        }
        else
        {
            buttonOn = true;
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
