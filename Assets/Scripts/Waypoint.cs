using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint nextPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnDrawGizmos()
    {
        if(nextPoint != null)
            Gizmos.DrawLine(transform.position + Vector3.down * 6, nextPoint.transform.position + Vector3.down * 6);
    }
}
