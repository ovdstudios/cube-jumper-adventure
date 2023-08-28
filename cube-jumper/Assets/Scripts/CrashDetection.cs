using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour
{

    public WinLoseCondition winLoseCondition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) 
    {
      
      if(other.collider.tag == "Player")
      {
        winLoseCondition.LoseLevel();
        ReloadScene();
        
      }
    }

    public void ReloadScene()
    {
      SceneManager.LoadScene(0);
    }
}
