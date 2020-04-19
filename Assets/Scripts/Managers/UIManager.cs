using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        scoreValueText = GameObject.Find("ScoreValueText").GetComponent<TMP_Text>();
        
    }
    
    public void Pulse()
    {
        foreach(Animator a in animators)
        {
            a.SetTrigger("Pulse");
        }
        DanceButtons.Instance.NewDirection();
    }

    public void UpdateScoreUI()
    {
        scoreValueText.text = ""+GameManager.Instance.Score;
    }
}
