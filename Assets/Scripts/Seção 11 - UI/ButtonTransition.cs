using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTransition : MonoBehaviour
{
    private Selectable _currButton;

    private short _currButtonIndex;
    // Start is called before the first frame update
    void Start()
    {
        _currButton = transform.GetChild(0).GetComponent<Selectable>();
        _currButtonIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _currButtonIndex++;
            if (_currButtonIndex == transform.childCount)
                _currButtonIndex = 0;
            _currButton = transform.GetChild(_currButtonIndex).GetComponent<Selectable>();
            _currButton.Select();
        }
        
    }
}
