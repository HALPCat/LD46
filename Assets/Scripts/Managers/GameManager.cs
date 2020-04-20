using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region singleton pattern
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    
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

    [SerializeField]
    public bool firstDancePressed = false;

    private int _score = 0;
    private int _comboModifier = 1;
    public float initialComboTime = 3;
    [SerializeField]
    private float _comboTimer;

    public int lastScoreIncrease = 0;

    public bool gameOver = false;
    public bool gamePaused = false;

    public int Score{
        get{ return _score; }
    }
    public int ComboModifier{
        get{ return _comboModifier; }
    }

    void Update()
    {
        if(ComboModifier > 1)
        {
            _comboTimer -= Time.deltaTime;
            if(_comboTimer <= 0)
            {
                IncreaseComboModifier(-1);
            }
        }
        if(Input.GetButtonDown("Cancel"))
        {
            PauseGame(!gamePaused);
        }
    }

    public void IncreaseComboModifier(int increment)
    {
        _comboModifier += increment;
        _comboTimer = initialComboTime * Mathf.Pow(0.8f, _comboModifier-1);
        UIManager.Instance.UpdateComboUI();
    }

    public void ResetComboModifier()
    {
        _comboModifier = 1;
        _comboTimer = initialComboTime;
        UIManager.Instance.UpdateComboUI();
    }

    public void AddScore(int increment)
    {
        _score += increment;
        lastScoreIncrease = increment;
        UIManager.Instance.UpdateScoreUI();
    }

    public void ChangeScene(int sceneIndex)
    {
        UpdateHiScore(SceneManager.GetActiveScene().buildIndex, _score);
        SceneManager.LoadScene(sceneIndex);
        MusicManager.Instance.StopMusic();
        firstDancePressed = false;
        gameOver = false;
        _score = 0;
        if(sceneIndex == 0)
        {
            MusicManager.Instance.PlayMusic(MusicManager.Instance.musicTracks[0]);
        }
    }

    void UpdateHiScore(int stage, int newScore)
    {
        Debug.Log("Updating hiScore on stage " + stage + " with score " + newScore);
        if(PlayerPrefs.GetInt("stage" + stage +"Score") < newScore)
        {
            Debug.Log("new score is higher");
            PlayerPrefs.SetInt("stage" + stage +"Score", newScore);
        }else{
            Debug.Log("new score is not higher");
        }
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex != 4)
        {
            ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else{
            ChangeScene(0);
        }
    }

    public void EndGame()
    {
        gameOver = true;
        UIManager.Instance.ShowEndScreen(true);
    }

    public void PauseGame(bool paused)
    {
        if(gameOver || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            return;
        }
        MusicManager.Instance.PauseMusic(paused);
        UIManager.Instance.ShowPauseMenu(paused);
        gamePaused = paused;

        if(paused)
        {
            Time.timeScale = 0;
        }else{
            Time.timeScale = 1;
        }
    }
}
