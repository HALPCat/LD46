using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region singleton pattern
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }
    
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

    Canvas canvas;
    public Animator[] animators;

    public TMP_Text scoreValueText;

    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        animators = canvas.GetComponentsInChildren<Animator>();
        SceneManager.activeSceneChanged += GetGameSceneComponents;
    }
    
    private void GetGameSceneComponents(Scene current, Scene next)
    {
        scoreValueText = GameObject.Find("ScoreValueText").GetComponent<TMP_Text>();
        canvas = FindObjectOfType<Canvas>();
        animators = canvas.GetComponentsInChildren<Animator>();
    }

    private void GetGameSceneComponents()
    {
        scoreValueText = GameObject.Find("ScoreValueText").GetComponent<TMP_Text>();
        canvas = FindObjectOfType<Canvas>();
        animators = canvas.GetComponentsInChildren<Animator>();
    }

    public void Pulse(bool success)
    {
        foreach(Animator a in animators)
        {
            if(success){
                a.SetTrigger("Pulse");
            }else{
                a.SetTrigger("FailPulse");
            }
        }
        DanceButtons.Instance.NewDirection();
    }

    public void UpdateScoreUI()
    {
        if(scoreValueText == null)
        {
            GetGameSceneComponents();
        }
        scoreValueText.text = ""+GameManager.Instance.Score;
    }
}
