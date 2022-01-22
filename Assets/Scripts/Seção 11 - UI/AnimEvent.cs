using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    private AudioSource _aS;

    private void Awake()
    {
        _aS = GetComponent<AudioSource>();
    }

    void PlayMsg()
    {
        _aS.Play();
    }
}
