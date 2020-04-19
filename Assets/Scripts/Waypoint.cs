using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint nextPoint;
    public float stopTime = 0;
    public bool firstWayPoint;
    public bool lastWayPoint = false;
    private float storedStopTime;

    void Start()
    {
        storedStopTime = stopTime;
        if(firstWayPoint)
        {
            stopTime = 604800;
        }
        if(nextPoint == null)
        {
            lastWayPoint = true;
        }
    }

    void OnDrawGizmos()
    {
        if(nextPoint != null)
            Gizmos.DrawLine(transform.position + Vector3.down * 6, nextPoint.transform.position + Vector3.down * 6);
    }

    public void RestoreStopTime()
    {
        stopTime = storedStopTime;
    }
}
