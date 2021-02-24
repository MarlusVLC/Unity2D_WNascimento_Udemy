using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource song;
    
    // Start is called before the first frame update
    void Start()
    {
        song = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (song.isPlaying)
            {
                song.Pause();
            }
            else
            {
                song.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
            song.Stop();
    }
}
