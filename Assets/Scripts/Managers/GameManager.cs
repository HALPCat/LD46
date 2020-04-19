using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private int _score = 0;

    public int Score{
        get{ return _score; }
    }

    public void AddScore(int increment)
    {
        _score += increment;
        UIManager.Instance.UpdateScoreUI();
    }
}
