using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopMusicOnFail()
    {
        if(musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public void StopMusicOnMenu()
    {
        if(musicSource !=null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    } 
}
