using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioRefCounter : MonoBehaviour
{
    private AudioSource sfx;
    
    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!sfx.isPlaying)
            Destroy(this.gameObject);
    }
}
