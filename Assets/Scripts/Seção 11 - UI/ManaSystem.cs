using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaSystem : MonoBehaviour
{

    [SerializeField] private int startValue = 100;
    [SerializeField] private int manaUse;
    [SerializeField] private int manaRec;

    [SerializeField] private TextMeshProUGUI manaString;
    [SerializeField] private Image manaIcon;

    private float _currValue;
    // Start is called before the first frame update
    void Awake()
    {
        _currValue = startValue;
    }

    private void Start()
    {
        UpdateString();
    }

    // Update is called once per frame
    void Update()
    {
        RecoverMana();
        ReduceMana();
    }

    void UpdateString()
    {
        _currValue = Mathf.Clamp(_currValue, 0, startValue);
        manaString.text = _currValue.ToString();
    }

    void ReduceMana()
    {
        if (Input.GetKey(KeyCode.KeypadMinus) && _currValue > 0)
        {
            _currValue -= manaUse;
            manaIcon.fillAmount = _currValue / startValue;
            UpdateString();    
        }
         
    }
    
    void RecoverMana()
    {
        if (Input.GetKey(KeyCode.KeypadPlus) && _currValue < startValue)
        {
            _currValue += manaRec;
            manaIcon.fillAmount = _currValue / startValue;
            UpdateString();    
        }
         
    }
}
