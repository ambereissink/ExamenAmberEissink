using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int goodPoints = 0;
    public int badPoints = 0;
    public TMP_Text goodPointsText;
    public TMP_Text badPointsText;
    Hideouts hideOuts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        goodPointsText.text = goodPoints.ToString();
        badPointsText.text = badPoints.ToString();
    }
    void NextQuestion() 
    {
        if (goodPoints == 5)
        {
            //disable this question object UI
            //enable next question object UI
            //disable alarmbellen buttons but keep appearance
            hideOuts.dialogueText.text = "Vragen compleet, door naar het volgende onderdeel!";
        }
    }

}
