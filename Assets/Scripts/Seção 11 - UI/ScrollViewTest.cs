using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewTest : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.001f;

    private ScrollRect _scrollRect;
    // Start is called before the first frame update
    void Start()
    {
        _scrollRect = GetComponent<ScrollRect>();
        _scrollRect.horizontalScrollbar.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_scrollRect.horizontalScrollbar.value < 1)
            _scrollRect.horizontalScrollbar.value += scrollSpeed;
    }
}
