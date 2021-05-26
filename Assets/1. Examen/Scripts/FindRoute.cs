using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRoute : MonoBehaviour
{
    public int currentGraden;
    public WindDirection WD;
    // Start is called before the first frame update
    void Start()
    {
        WindDirection WD = gameObject.GetComponent<WindDirection>();
        //WD.graden = currentGraden;
        FindClosestHideout();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FindClosestHideout()
    {
        float distanceToClosestHideout = Mathf.Infinity;
        Hideouts closestHideout = null;
        Hideouts[] allHideOuts = GameObject.FindObjectsOfType<Hideouts>();

        foreach (Hideouts currentHideout in allHideOuts)
        {
            float distanceToHideout = (currentHideout.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToHideout < distanceToClosestHideout)
            {
                distanceToClosestHideout = distanceToHideout;
                closestHideout = currentHideout;
            }
        }
        Debug.Log("Dit is de closest hideout: " + closestHideout);
    }

    void WindCheck()
    {
        /*
        if (currentGraden >= 1 && currentGraden <= 90)
        {
            Debug.Log("Dit is NE");
        }
        else if (currentGraden >= 91 && currentGraden <= 180)
        {
            Debug.Log("Dit is SE");
        }
        else if (currentGraden >= 181 && currentGraden <= 270)
        {
            Debug.Log("Dit is SW");
        }
        else if (currentGraden >= 271 && currentGraden <= 360)
        {
            Debug.Log("Dit is NW");
        }
        */
    }
}
