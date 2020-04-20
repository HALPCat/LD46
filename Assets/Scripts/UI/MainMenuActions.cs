using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuActions : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider soundVolumeSlider;
    public bool optionsEnabled = false;
    public GameObject optionsHolder;

    void Start()
    {
        musicVolumeSlider.onValueChanged.AddListener(delegate {MusicManager.Instance.AdjustMusicVolume(musicVolumeSlider.value); });
        soundVolumeSlider.onValueChanged.AddListener(delegate {MusicManager.Instance.AdjustSoundVolume(soundVolumeSlider.value); });
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
            musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.25f);
            soundVolumeSlider.value = PlayerPrefs.GetFloat("soundVolume", 0.25f);
        }else{
            optionsHolder.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
