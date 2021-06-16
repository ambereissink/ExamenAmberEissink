using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FindRoute : MonoBehaviour
{
    public float currentGraden => WD.graden; //the => basically makes it so when you call currentGraden instead it calls WD.graden.
    public WindDirection WD;
    public Transform alleAlarmColliders;


    public Hideout correctHideout;

    ScoreManager scoreManager;
    AlarmManager alarm;

    List<Hideout> hideouts = new List<Hideout>();

    public Hideout quickCheck;

    public float distanceForAlarm = 340;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        alarm = FindObjectOfType<AlarmManager>();
        SetClosest(); //Gets called and sets correctHideout.


    }

    public void CreateNewCorrectHideout() //calls the closest hideout and generates new windirection
    {
        WD.ChangeDirection();
        SetClosest();
    }

    void SetClosest()
    {
        if (FindObjectsOfType<Hideout>().Length == 0) //If there are no hideouts, leave method.
        {
            return;
        }

        hideouts = new List<Hideout>();
        hideouts = FindObjectsOfType<Hideout>().ToList();

        bool isPlayerInRange = false;
        for(int i = 0; i < alleAlarmColliders.childCount; i++)
        {
            float distanceToAlarmcode = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(alleAlarmColliders.GetChild(i).position.x, alleAlarmColliders.GetChild(i).position.z));

            //Debug.Log(alleAlarmColliders.GetChild(i).name + ": " + distanceToAlarmcode);
            if (distanceToAlarmcode <= distanceForAlarm && alleAlarmColliders.GetChild(i).name.Contains(alarm.currentAlarm.ToString())) //checks distance between player and alarmcollider in worldspace and checks current alarm
            {
                isPlayerInRange = true;
            }
        }
        if (isPlayerInRange || alarm.currentAlarm == 0)
        {
            List<Hideout> correctHideouts = new List<Hideout>(); //Make a list for new hideouts
            correctHideouts = WindDirectionTest(hideouts);                   //Set list equal to the wind direction test. comment this out if you dont want wind direction.
                                                                             //correctHideouts = FindObjectsOfType<Hideout>().ToList();
            if (correctHideouts.Count == 0)
            {                      //if there is no correct hideout in wind correction test
                correctHideouts = FindObjectsOfType<Hideout>().ToList();    //reset list to all hideouts
            }
            correctHideouts.Sort((h1, h2) => DistanceCheck(h1, h2)); //Sorts distance. Closest is at 0 in the list the further away they get, the further down the list.

            correctHideout = correctHideouts[0];        //set closet to first in the list.
        }
        else
        {
            correctHideout = quickCheck;
        }

        Debug.Log("The Correct Hideout is :" + correctHideout);
    }

 

    List<Hideout> WindDirectionTest(List<Hideout> hide)
    {
        List<Hideout> correctInWindrichting = new List<Hideout>();
        foreach (Hideout h in hide)
        {
            Vector3 dir = h.transform.position - transform.position; //Get the direction between 2 objects
            float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg; //atan2 converts a vector direction into radians which we convert to degrees with Rad2Deg
            angle -= 90;  //-90 degrees. because the visual is offset with 90 degrees.


            float anglediff = (currentGraden - angle + 180 + 360) % 360 - 180;    //Normalizes angle to always be between 0 and 360 and then shifts it to -180 to 180

            if (anglediff <= 90 && anglediff >= -90)
            {
                correctInWindrichting.Add(h);   //if distance is within 90 degrees on either side (so 180 degrees) its within the wind direction
            }
        }
        return correctInWindrichting;
    }


    public void CheckCorrect(Hideout h) 
    {
     //checks if selected hideout is correct hideout
        
        if ((h as Hideout) == correctHideout)
        {
            scoreManager.goodPoints++;

            Debug.Log("Winnaar");
        }
        else
        {
            scoreManager.badPoints++;
            Debug.Log("Niet winnaar!");
        }
       
        
    }


    int DistanceCheck(Hideout h1, Hideout h2)
    {
        //Returns which distance is the closest
        return Vector2.Distance(
            new Vector2(h1.transform.position.x, h1.transform.position.z), 
            new Vector2(transform.position.x, transform.position.z))
            .CompareTo(
            Vector2.Distance(
                new Vector2(h2.transform.position.x, h2.transform.position.z), 
                new Vector2(transform.position.x, transform.position.z)));
    }

}
