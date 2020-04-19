using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightScript : MonoBehaviour
{
    public Waypoint startPoint;
    public Waypoint endPoint;
    private float startTime;
    public float speed = 1;

    [SerializeField]
    private float timer = 0;

    private float journeyLength;

    public bool moving = false;
    float fractionOfJourney;
    float distCovered;
    bool fired =false;

    void Start()
    {
        transform.position = WaypointManager.Instance.GetFirstWaypoint().transform.position;

        startPoint = WaypointManager.Instance.GetFirstWaypoint();
        endPoint = WaypointManager.Instance.GetNextWaypoint(startPoint);
        
        timer = startPoint.stopTime;

        TurnOn();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if(!moving){
                TurnOn();
            }else{
                TurnOff();
            }
        }
        if(moving)
        {
            if(timer <= 0)
            {
                if(!fired)
                {
                    TurnOn();
                    fired = true;
                }
                distCovered = (Time.time - startTime) * speed;
                fractionOfJourney = distCovered / journeyLength;
                transform.position = Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, fractionOfJourney);
                if(fractionOfJourney >= 1)
                {
                    NewWaypoint();
                    fired = false;
                }
            }else{
                timer -= Time.deltaTime;
            }
        }


    }

    void NewWaypoint()
    {
        startPoint = endPoint;
        endPoint = WaypointManager.Instance.GetNextWaypoint(startPoint);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPoint.transform.position, endPoint.transform.position);
        timer = startPoint.stopTime;
    }

    void TurnOn()
    {
        moving = true;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPoint.transform.position, endPoint.transform.position);
    }

    void TurnOff()
    {
        moving = false;
    }
}
