using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputFieldTest : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text, text2;

    private TMP_InputField _inputField;
    void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
        
    }

    void Update()
    {
        if (_inputField.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _inputField.onEndEdit.Invoke(_inputField.text);
            }
        }
    }

    public void UpdateRealtime()
    {
        text.text = _inputField.text;
    }

    public void UpdateAtConfirm()
    {
        text2.text = _inputField.text;
        _inputField.text = "";
    }
}
