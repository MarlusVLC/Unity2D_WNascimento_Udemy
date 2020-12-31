using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public int coins;
    public AudioClip coinSfx;
    // public GameObject audioRef;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.ToLower().Contains("coin"))
        {
            coins++;
            // Instantiate(audioRef, other.transform.position, Quaternion.identity);
            AudioManager.getInstance.PlayAudio(coinSfx);
            //Debug.Log("Moedas coletadas: " + coins);
            Destroy(other.gameObject);
        }
    }
}
