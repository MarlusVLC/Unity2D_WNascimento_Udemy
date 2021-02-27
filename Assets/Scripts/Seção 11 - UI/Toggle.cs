﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI txt;
    private Toggle _toggle;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


    public void SetOption()
    {
        if (transform.childCount >= 1)
            txt.text = transform.GetChild(1).GetComponent<Text>().text;
    }
}
