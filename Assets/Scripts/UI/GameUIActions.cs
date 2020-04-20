using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIActions : MonoBehaviour
{
    public void BackToMainMenu()
    {
        GameManager.Instance.PauseGame(false);
        GameManager.Instance.ChangeScene(0);
    }

    public void NextStage()
    {
        GameManager.Instance.NextLevel();
    }
}
