using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIActions : MonoBehaviour
{
    public void BackToMainMenu()
    {
        GameManager.Instance.ChangeScene(0);
    }
}
