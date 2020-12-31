using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag.ToLower().Contains("wood".ToLower()))
    //     {
    //         Destroy(other.gameObject);
    //     }
    // }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.ToLower().Contains("wood".ToLower()))
        {
            Destroy(other.gameObject);
        }
    }
    
    // private void OnCollisionStay2D(Collision2D other)
    // {
    //     if (other.gameObject.tag.ToLower().Contains("wood".ToLower()))
    //     {
    //         Destroy(other.gameObject);
    //     }
    // }
}
