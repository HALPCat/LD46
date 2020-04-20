using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceController : MonoBehaviour
{
    DanceButtons.DanceDirection _pressedDirection;
    private bool _dancePressed;
    public bool isInSpotlight = false;
    Animator animator;
    PartyInfluence partyInfluence;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        partyInfluence = GetComponentInChildren<PartyInfluence>();
    }

    void Update()
    {
        if(!GameManager.Instance.gamePaused)
        {
            _dancePressed = false;
            UpdatePressedDirection();

            if(_dancePressed && !GameManager.Instance.gameOver)
            {
                if(isInSpotlight)
                {
                    if(!GameManager.Instance.firstDancePressed){
                        GameManager.Instance.firstDancePressed = true;
                    }

                    if(DanceButtons.Instance.CheckDirection(_pressedDirection))
                    {
                        DanceSuccess(true);
                    }else{
                        DanceSuccess(false);
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
    }

    private void DanceSuccess(bool success)
    {
        if(success)
        {
            DanceButtons.Instance.NewDirection();
            UIManager.Instance.Pulse(true);
            MusicManager.Instance.PlaySound(MusicManager.Instance.soundAudioClips[0]);
            GameManager.Instance.AddScore(2 * GameManager.Instance.ComboModifier);
            GameManager.Instance.IncreaseComboModifier(1);
            //Partygoers
            partyInfluence.Influence();

        }else{
            DanceButtons.Instance.NewDirection();
            UIManager.Instance.Pulse(false);
            MusicManager.Instance.PlaySound(MusicManager.Instance.soundAudioClips[1]);
            GameManager.Instance.AddScore(-2);
            GameManager.Instance.ResetComboModifier();
        }
    }

    void UpdatePressedDirection()
    {
        if(Input.GetButtonDown("DownDance"))
        {
            _pressedDirection = DanceButtons.DanceDirection.Down;
            animator.SetTrigger("Dance1");
            _dancePressed = true;
        }else if(Input.GetButtonDown("LeftDance"))
        {
            _pressedDirection = DanceButtons.DanceDirection.Left;
            animator.SetTrigger("Dance2");
            _dancePressed = true;
        }else if(Input.GetButtonDown("RightDance"))
        {
            _pressedDirection = DanceButtons.DanceDirection.Right;
            animator.SetTrigger("Dance3");
            _dancePressed = true;
        }else if(Input.GetButtonDown("UpDance"))
        {
            _pressedDirection = DanceButtons.DanceDirection.Up;
            animator.SetTrigger("Dance4");
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
