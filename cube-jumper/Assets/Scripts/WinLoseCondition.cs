using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCondition : MonoBehaviour
{ 

    private bool gameEnded;
    public void WinLevel()
    {
        if (!gameEnded)
        {
            Debug.Log("You Win!");
            gameEnded = true;
        }
    }

    public void LoseLevel()
    {
        if (!gameEnded)
        {
            Debug.Log("You Lose..");
            gameEnded = true;
        }
    }

    public void ReloadManager(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
