using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLoseCondition : MonoBehaviour
{
    public GameOverScreen gameOver;
    private bool gameEnded;

    public void WinLevel()
    {
        if (!gameEnded)
        {
            Debug.Log("You Win!");
            gameOver.GameOver();
            gameEnded = true;
        }
    }

    public void LoseLevel()
    {
        if (!gameEnded)
        {
            Debug.Log("You Lose..");
            gameOver.GameOver();
            gameEnded = true;
        }
    }
}
