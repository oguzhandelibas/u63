using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int totalGameDay = 176;
    public bool isGameContinue;
    public bool gameDone;

    private void Start()
    {
        totalGameDay = 176;
        gameDone = false;
        isGameContinue = true;
        SetDayStatus(0);
    }

    public void SetDayStatus(int minusValue)
    {
        totalGameDay -= minusValue;
        UIManager.Instance.UpdateDay(totalGameDay);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
