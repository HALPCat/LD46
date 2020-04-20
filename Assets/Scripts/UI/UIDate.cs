using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDate : MonoBehaviour
{
    TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = System.DateTime.Now.ToString("hh:mm");
    }
}
