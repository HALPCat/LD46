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
    private int _comboModifier = 1;
    public float initialComboTime = 3;
    [SerializeField]
    private float _comboTimer;

    public int lastScoreIncrease = 0;

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
        SceneManager.LoadScene(sceneIndex);
        MusicManager.Instance.StopMusic();
        firstDancePressed = false;
    }

    public void EndGameScreen()
    {

    }
}
