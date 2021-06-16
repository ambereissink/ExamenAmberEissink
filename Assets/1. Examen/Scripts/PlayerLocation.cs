using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocation : MonoBehaviour
{
    public List<Vector2> positionList = new List<Vector2>();

    public void OnEnable()
    {
        SetRandomPosition();
    }

    public void SetRandomPosition() //sets random positions for player in inspector
    {
        int randomNum = Random.Range(0, positionList.Count);
        transform.position = new Vector3(positionList[randomNum].x, -53, positionList[randomNum].y);
    }
}
