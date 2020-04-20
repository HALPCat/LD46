using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundOnRelease : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    //OnPointerDown is also required to receive OnPointerUp callbacks
    public void OnPointerDown(PointerEventData eventData)
    {
    }

    //Do this when the mouse click on this selectable UI object is released.
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("The mouse click was released");
        MusicManager.Instance.PlaySound(MusicManager.Instance.soundAudioClips[0]);
    }
}
