using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceController : MonoBehaviour
{
    DanceButtons.DanceDirection _pressedDirection;
    private bool _dancePressed;

    void Start()
    {
        
    }

    void Update()
    {
        _dancePressed = false;
        UpdatePressedDirection();

        if(_dancePressed && DanceButtons.Instance.CheckDirection(_pressedDirection))
        {
            DanceButtons.Instance.NewDirection();
            UIManager.Instance.Pulse();
        }
    }

    void UpdatePressedDirection()
    {
        if(Input.GetButtonDown("DownDance"))
        {
            _pressedDirection = DanceButtons.DanceDirection.Down;
            _dancePressed = true;
        }else if(Input.GetButtonDown("LeftDance"))
        {
            _pressedDirection = DanceButtons.DanceDirection.Left;
            _dancePressed = true;
        }else if(Input.GetButtonDown("RightDance"))
        {
            _pressedDirection = DanceButtons.DanceDirection.Right;
            _dancePressed = true;
        }else if(Input.GetButtonDown("UpDance"))
        {
            _pressedDirection = DanceButtons.DanceDirection.Up;
            _dancePressed = true;
        }
    }
}
