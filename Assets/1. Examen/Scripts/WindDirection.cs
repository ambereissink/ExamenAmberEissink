using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindDirection : MonoBehaviour
{
    public float graden;
    public TextMeshProUGUI textMesh;
    public RectTransform windIndicator;


    void Start()
    {
        W_Direction();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void W_Direction()
    {

        graden = Random.Range(1,360);
        Debug.Log("Wind Direction = " + graden);
        textMesh.text = (360-graden).ToString() + " °";
        windIndicator.rotation = Quaternion.Euler(0, 0, graden);
    }

}
