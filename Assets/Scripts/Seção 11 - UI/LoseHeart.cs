using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseHeart : MonoBehaviour
{
    private Animator _anim;
    private Image _image;
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        if (transform.childCount > 0)
        {
            _image = transform.GetChild(0).GetComponent<Image>();
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _image.fillAmount = 1f;
        }
    }

    public void LosePiece()
    {
        if (_image.fillAmount > 0)
            _anim.SetTrigger("LostLife");
        _image.fillAmount -= 0.25f;
    }
}
