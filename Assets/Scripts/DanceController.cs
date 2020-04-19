using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceController : MonoBehaviour
{
    DanceButtons.DanceDirection _pressedDirection;
    private bool _dancePressed;
    public bool isInSpotlight = false;

    void Update()
    {
        _dancePressed = false;
        UpdatePressedDirection();

        if(_dancePressed)
        {
            if(isInSpotlight)
            {
                if(!GameManager.Instance.firstDancePressed){
                    GameManager.Instance.firstDancePressed = true;
                }

                if(DanceButtons.Instance.CheckDirection(_pressedDirection))
                {
                    DanceButtons.Instance.NewDirection();
                    UIManager.Instance.Pulse(true);
                    GameManager.Instance.AddScore(2);
                }else{
                    DanceButtons.Instance.NewDirection();
                    UIManager.Instance.Pulse(false);
                    GameManager.Instance.AddScore(-2);
                }
            }else{
                if(DanceButtons.Instance.CheckDirection(_pressedDirection))
                {
                    DanceButtons.Instance.NewDirection();
                    UIManager.Instance.Pulse(true);
                }else{
                    DanceButtons.Instance.NewDirection();
                    UIManager.Instance.Pulse(false);
                }
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Spotlight"))
        {
            isInSpotlight = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Spotlight"))
        {
            isInSpotlight = false;
        }
    }
}
