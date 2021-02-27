using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTest : MonoBehaviour
{
    private Canvas _canvas;
    private CanvasScaler _canvasScaler;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _canvas = GetComponent<Canvas>();
        _canvasScaler = GetComponent<CanvasScaler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            _canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        }
 
        

    }
}
