using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    CrashDetection reloadManager;

    // Start is called before the first frame update
    void Start()
    {
        reloadManager = GameObject.FindGameObjectWithTag("Obstacle").GetComponent<CrashDetection>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            reloadManager.ReloadScene();
        }   
    }
}