using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFailMusic : MonoBehaviour
{
    [SerializeField] AudioSource failSound;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FailSound()
    {
       if(failSound != null)
        {
           failSound.Play();
        }
        
    }
}
