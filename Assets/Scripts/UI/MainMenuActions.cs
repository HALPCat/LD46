using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuActions : MonoBehaviour
{
    public Slider volumeSlider;
    public bool optionsEnabled = false;
    public GameObject optionsHolder;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(delegate {MusicManager.Instance.AdjustVolume(volumeSlider.value); });
    }

    public void StartGame()
    {
        GameManager.Instance.ChangeScene(1);
    }

    public void Options()
    {
        optionsEnabled = !optionsEnabled;
        if(optionsEnabled)
        {
            optionsHolder.SetActive(true);
        }else{
            optionsHolder.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
