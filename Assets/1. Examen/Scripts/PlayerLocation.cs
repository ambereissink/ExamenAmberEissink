using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocation : MonoBehaviour
{
    public void OnEnable()
    {
        Debug.Log(GetComponent<RectTransform>().localPosition);
    }
}
