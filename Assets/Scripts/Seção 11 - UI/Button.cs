using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private Image _bgImage;

    private float _bgAlpha;
    // Start is called before the first frame update
    void Start()
    {
        _bgImage = GetComponent<Image>();
        _bgAlpha = _bgImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reduceAlpha(float reducer)
    {
        _bgAlpha -= reducer;
        _bgImage.color = new Color(_bgImage.color.r, _bgImage.color.b, _bgImage.color.g, _bgAlpha);
    }
}
