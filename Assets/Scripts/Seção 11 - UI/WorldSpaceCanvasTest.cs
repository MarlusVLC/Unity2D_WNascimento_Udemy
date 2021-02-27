using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceCanvasTest : MonoBehaviour
{
    private RectTransform _rectTransform;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        _rectTransform.Rotate(new Vector3(0,Input.GetAxis("Horizontal"),0));
    }
}
