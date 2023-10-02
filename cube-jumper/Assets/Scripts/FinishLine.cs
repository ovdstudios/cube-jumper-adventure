using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
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

     private void OnTriggerEnter(Collider other) 
     {
        if(other.tag == "Player")
        {
            winLoseCondition.WinLevel();
            //reloadManager.ReloadScene();  
        }
     }
}