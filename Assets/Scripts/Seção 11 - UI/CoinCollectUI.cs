using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollectUI : MonoBehaviour
{
    public int coins;
    public AudioClip coinSfx;
    
    [SerializeField] private TextMeshProUGUI coinsTxt;
    [SerializeField] private Image statusImg;
    [SerializeField] private Sprite[] statusSprites;
    [SerializeField] private RawImage rawImage;
    // [SerializeField] private Button button;
    
    [SerializeField] private
    // public GameObject audioRef;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        statusImg.sprite = statusSprites[coins];
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.ToLower().Contains("coin"))
        {
            coins++;
            coinsTxt.text = coins + "COINS";
            // Instantiate(audioRef, other.transform.position, Quaternion.identity);
            AudioManager.getInstance.PlayAudio(coinSfx);
            //Debug.Log("Moedas coletadas: " + coins);
            Destroy(other.gameObject);
            // statusImg.fillAmount -= 0.25f;
        }

    }
}
