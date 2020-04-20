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
    public bool stageSelectEnabled = false;
    public GameObject optionsHolder;
    public GameObject stageSelectHolder;

    public TMP_Text[] hiScoreTexts;

    void Start()
    {
        musicVolumeSlider.onValueChanged.AddListener(delegate {MusicManager.Instance.AdjustMusicVolume(musicVolumeSlider.value); });
        soundVolumeSlider.onValueChanged.AddListener(delegate {MusicManager.Instance.AdjustSoundVolume(soundVolumeSlider.value); });
    }

    public void StartGame()
    {
        GameManager.Instance.ChangeScene(1);
    }

    public void LoadStage(int stageIndex)
    {
        GameManager.Instance.ChangeScene(stageIndex);
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

    public void StageSelect()
    {
        stageSelectEnabled = !stageSelectEnabled;
        stageSelectHolder.SetActive(stageSelectEnabled);
        if(stageSelectEnabled)
        {
            for(int i = 0; i < hiScoreTexts.Length; i++)
            {
                int stage = i+1;
                Debug.Log("Updating text and index " + i + " with stage " + stage + " score");
                hiScoreTexts[i].text = "" + PlayerPrefs.GetInt("stage" + stage +"Score", 0);
            }
        }
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
