using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
   public int gameStartScene;
    private TextGlowOnHover _coroutine;
   
   public void StartGame()
   {
    _coroutine = GetComponent<TextGlowOnHover>();
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
