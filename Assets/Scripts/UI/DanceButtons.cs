using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceButtons : MonoBehaviour
{
    #region singleton pattern
    private static DanceButtons _instance;
    public static DanceButtons Instance { get { return _instance; } }
    
    void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        } else {
            _instance = this;
        }
    }
    #endregion 

    public enum DanceDirection { Down, Left, Right, Up }
    [SerializeField]
    private DanceDirection _currentDirection;

    void Start()
    {
        NewDirection();
    }

    public bool CheckDirection(DanceDirection direction)
    {
        if(direction == _currentDirection)
        {
            return true;
        }else{
            return false;
        }
    }

    public void NewDirection()
    {
        _currentDirection = (DanceDirection)Random.Range(0, 3);
        EnableButton(_currentDirection);
    }

    private void EnableButton(DanceDirection direction)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        switch(direction)
        {
            case DanceDirection.Down:
                transform.GetChild(0).gameObject.SetActive(true);
                break;
            case DanceDirection.Left:
                transform.GetChild(1).gameObject.SetActive(true);
                break;
            case DanceDirection.Right:
                transform.GetChild(2).gameObject.SetActive(true);
                break;
            case DanceDirection.Up:
                transform.GetChild(3).gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}
