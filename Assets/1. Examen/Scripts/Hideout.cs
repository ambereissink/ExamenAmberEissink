using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;



public class Hideout : MonoBehaviour
{
    public TMP_Text dialogueText;

    //public List<GameObject> hideOuts = new List<GameObject>();
    private void Start()
    {

    }
    private void Update()
    {
        // Check for mouse input
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Hideout")
                {

                    Debug.Log("This is " + hit.transform.name);
                    dialogueText.text = "Dit is " + hit.transform.name;
                }
            }

        }

    }
}


