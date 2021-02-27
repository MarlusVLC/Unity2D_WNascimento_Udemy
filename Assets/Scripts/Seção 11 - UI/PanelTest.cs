using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTest : MonoBehaviour
{

    private RawImage _rawImage;
    // Start is called before the first frame update
    void Start()
    {
        _rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {

        Rect _newRect = _rawImage.uvRect;
        _newRect.x += 0.01f;
        _rawImage.uvRect = _newRect;
    }
}
