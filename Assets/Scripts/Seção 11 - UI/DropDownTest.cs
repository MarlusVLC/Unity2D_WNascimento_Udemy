using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropDownTest : MonoBehaviour
{

    // private Dropdown _dropdown;
    private TMP_Dropdown _dropdown;
    // Start is called before the first frame update
    void Start()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrintValue()
    {
        Debug.Log(_dropdown.captionText.GetParsedText());
    }
}
