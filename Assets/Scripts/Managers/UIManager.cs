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
    public TMP_Text comboText;
    public TMP_Text comboValueText;

    void Start()
    {
        SceneManager.activeSceneChanged += GetGameSceneComponents;
        UpdateComboUI();
    }
    
    private void GetGameSceneComponents(Scene current, Scene next)
    {
        scoreValueText = GameObject.Find("ScoreValueText").GetComponent<TMP_Text>();
        comboText = GameObject.Find("ComboText").GetComponent<TMP_Text>();
        comboValueText = GameObject.Find("ComboValueText").GetComponent<TMP_Text>();
        canvas = FindObjectOfType<Canvas>();
        animators = canvas.GetComponentsInChildren<Animator>();

    }

    private void GetGameSceneComponents()
    {
        scoreValueText = GameObject.Find("ScoreValueText").GetComponent<TMP_Text>();
        comboText = GameObject.Find("ComboText").GetComponent<TMP_Text>();
        comboValueText = GameObject.Find("ComboValueText").GetComponent<TMP_Text>();
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
        string incrementText;
        if(GameManager.Instance.lastScoreIncrease > 0){
            incrementText = " +" + GameManager.Instance.lastScoreIncrease;
        }else{
            incrementText = " " + GameManager.Instance.lastScoreIncrease;
        }
        scoreValueText.text = ""+GameManager.Instance.Score + incrementText;
    }

    public void UpdateComboUI()
    {
        if(comboValueText == null)
        {
            GetGameSceneComponents();
        }
        if(GameManager.Instance.ComboModifier <= 1)
        {
            comboText.gameObject.SetActive(false);
            comboValueText.gameObject.SetActive(false);
        }else{
            comboText.gameObject.SetActive(true);
            comboValueText.gameObject.SetActive(true);
            comboValueText.text = GameManager.Instance.ComboModifier + "x";
        }
    }
}
