using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeigthAnim : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D _rb;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.ToLower().Contains("player"))
        {
            _anim.SetBool("isInPendulumMove", false);
            _rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
