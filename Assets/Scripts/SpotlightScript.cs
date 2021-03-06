﻿using System.Collections;
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
        endPoint = startPoint.nextPoint;
        
        timer = startPoint.stopTime;

        TurnOn();
    }

    void Update()
    {
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
                if(timer > 302400 && GameManager.Instance.firstDancePressed)
                {
                    WaypointManager.Instance.waypoints[0].RestoreStopTime();
                    timer = WaypointManager.Instance.waypoints[0].stopTime;
                    MusicManager.Instance.PlayMusic(MusicManager.Instance.musicTracks[1]);
                }
            }
        }

        if(GameManager.Instance.firstDancePressed)
        {
            //Debug.Log("first dance pressed");
            if(!moving)
            {
                //Debug.Log("not moving");
                //Debug.Log("timer: " + timer);
                if(timer <= 0 && !GameManager.Instance.gameOver){
                    //Debug.Log("calling!!!");
                    GameManager.Instance.EndGame();
                }else{
                    timer -= Time.deltaTime;
                }
            }
        }
    }

    void NewWaypoint()
    {
        startPoint = endPoint;
        if(!endPoint.lastWayPoint){
            endPoint = startPoint.nextPoint;
            startTime = Time.time;
            journeyLength = Vector3.Distance(startPoint.transform.position, endPoint.transform.position);
            timer = startPoint.stopTime;
        }else{
            TurnOff();
            Debug.Log("End");
        }
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
        timer = startPoint.stopTime;
    }
}
