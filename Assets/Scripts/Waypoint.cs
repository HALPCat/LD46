using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint nextPoint;
    public float stopTime = 0;
    
    void OnDrawGizmos()
    {
        if(nextPoint != null)
            Gizmos.DrawLine(transform.position + Vector3.down * 6, nextPoint.transform.position + Vector3.down * 6);
    }
}
