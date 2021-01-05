using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource playerAudioSource;
    public AudioSource PlayerAudioSource
    {
        get
        {
            if(playerAudioSource==null)
            playerAudioSource=GetComponent<AudioSource>();

            return playerAudioSource;

        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
