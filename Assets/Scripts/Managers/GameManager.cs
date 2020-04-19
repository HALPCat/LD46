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

    public bool firstDancePressed = false;

    private int _score = 0;

    public int Score{
        get{ return _score; }
    }

    public void AddScore(int increment)
    {
        _score += increment;
        UIManager.Instance.UpdateScoreUI();
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        MusicManager.Instance.StopMusic();
        firstDancePressed = false;
    }
}
