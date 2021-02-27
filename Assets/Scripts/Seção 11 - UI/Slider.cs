using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{

    [SerializeField] private RawImage rawImage;

    private UnityEngine.UI.Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<UnityEngine.UI.Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SliderToImage()
    {
        rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, _slider.value);
    }
}
