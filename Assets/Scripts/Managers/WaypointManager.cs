using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    #region singleton pattern
    private static WaypointManager _instance;
    public static WaypointManager Instance { get { return _instance; } }
    
    void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion 

    public Waypoint[] waypoints;

    public Waypoint GetFirstWaypoint()
    {
        return waypoints[0];
    }

    public Waypoint GetNextWaypoint(Waypoint waypoint)
    {
        Waypoint nextWayPoint = null;
        bool finished = false;

        for(int i = 0; i < waypoints.Length; i++)
        {
            if(waypoints[i] == waypoint && !finished)
            {
                if(i == waypoints.Length-1)
                {
                    nextWayPoint = waypoints[0];
                    Debug.Log("Returning index 0");
                    finished = true;
                }else
                {
                    nextWayPoint = waypoints[i+1];
                    int newindex = i+1;
                    Debug.Log("Returning index " + newindex);
                    finished = true;
                }
            }
        }
        
        if(nextWayPoint == null){
            Debug.Log("Could not find waypoint");
        }

        return nextWayPoint;
    }
}
