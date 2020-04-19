using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceController : MonoBehaviour
{
    DanceButtons.DanceDirection _pressedDirection;
    private bool _dancePressed;

    void Update()
    {
        _dancePressed = false;
        UpdatePressedDirection();

        if(_dancePressed)
        {
            if(DanceButtons.Instance.CheckDirection(_pressedDirection))
            {
                DanceButtons.Instance.NewDirection();
                UIManager.Instance.Pulse();
                GameManager.Instance.AddScore(2);
            }else{
                GameManager.Instance.AddScore(-2);
            }
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
