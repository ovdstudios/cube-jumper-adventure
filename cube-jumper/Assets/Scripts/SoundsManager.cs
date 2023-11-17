using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] AudioSource jumpSource;
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioSource backgroundSource;
    [SerializeField] AudioClip backgroundClip;
    [SerializeField] AudioSource loseSoundSource;
    [SerializeField] AudioClip loseSoundClip;
    public  float normalBackgroundPitch;
    // Start is called before the first frame update
    void Start()
    {
        backgroundSource.loop = true;
        jumpSource.clip = jumpClip;
        backgroundSource.clip = backgroundClip;
        loseSoundSource.clip = loseSoundClip;
        //burda normal soundun pitchini alıyoruz.
        normalBackgroundPitch =backgroundSource.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJumpSound()
    {
        jumpSource.Play();

    }

    public void PlayBackgroundSource()
    {
        backgroundSource.Play();
    }

    public void PlayLoseSound()
    {
        loseSoundSource.Play();
    }

    public void SetBackgroundPitch(float pitch)
    {
        backgroundSource.pitch = pitch;
    }

}
