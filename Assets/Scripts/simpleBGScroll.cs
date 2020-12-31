using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleBGScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    public Renderer quad;


    private void Start()
    {
        quad = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(scrollSpeed * Time.deltaTime, 0);
        quad.material.mainTextureOffset += offset;

    }
}
