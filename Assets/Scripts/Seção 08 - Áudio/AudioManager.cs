using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource sounds;
    
    private static AudioManager INSTANCE = null; //SINGLETON
    public static AudioManager getInstance
    {
        get { return INSTANCE; }
    }
    
    
    // Start is called before the first frame update


    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
            sounds = GetComponent<AudioSource>();
        }
        else if (INSTANCE != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudio(AudioClip _audioClip)
    {
        sounds.clip = _audioClip;
        sounds.Play();
    }
}
