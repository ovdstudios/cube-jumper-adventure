using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseCondition : MonoBehaviour
{

    private bool gameEnded;
  public void WinLevel()
  {
    if(!gameEnded)
    {
         Debug.Log("You Won!");
         gameEnded = true;
    }
  }

  public void LoseLevel()
  {
    if(!gameEnded)
    {
        Debug.Log("You lost...");
        gameEnded = true;
    }
  }
}