﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnAsteroid : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        transform.position = startPos;
        print("Saiu da tela");
    }
}
