using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightScript : MonoBehaviour
{
    public Waypoint startPoint;
    public Waypoint endPoint;
    private float startTime;
    public float speed = 1;

    private float journeyLength;

    void Start()
    {
        transform.position = WaypointManager.Instance.GetFirstWaypoint().transform.position;

        startPoint = WaypointManager.Instance.GetFirstWaypoint();
        endPoint = WaypointManager.Instance.GetNextWaypoint(startPoint);

        startTime = Time.time;
        journeyLength = Vector3.Distance(startPoint.transform.position, endPoint.transform.position);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;

        float fractionOfJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, fractionOfJourney);
        if(fractionOfJourney >= 1)
        {
            startPoint = endPoint;
            endPoint = WaypointManager.Instance.GetNextWaypoint(startPoint);
            startTime = Time.time;
            journeyLength = Vector3.Distance(startPoint.transform.position, endPoint.transform.position);
        }
    }
}
