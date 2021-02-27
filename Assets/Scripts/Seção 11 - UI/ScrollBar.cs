using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt;
    
    private Scrollbar _scrollbar;

    // Start is called before the first frame update
    void Start()
    {
        _scrollbar = GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValueToString()
    {
        txt.text = _scrollbar.value.ToString();
    }
}
