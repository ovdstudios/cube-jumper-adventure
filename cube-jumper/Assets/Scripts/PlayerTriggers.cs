using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{  
    public WinLoseCondition winLoseCondition;
    CrashDetection reloadManager;

    void Start()
    {
        reloadManager = GameObject.FindGameObjectWithTag("Obstacle").GetComponent<CrashDetection>();
    }
    void Update()
    {
        if(transform.position.y < -15f)
        {
           Invoke("InvokeReloadScene",.5f);
            winLoseCondition.LoseLevel();
        }
    }

    private void InvokeReloadScene()
    {
        reloadManager.ReloadScene();
    }
}
