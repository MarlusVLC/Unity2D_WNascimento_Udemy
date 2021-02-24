using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    [SerializeField] private bool canRotate;
    [SerializeField] private float rotationRate;
    [SerializeField] private Transform ball;
    
    
    // Start is called before the first frame update
    void Start()
    {
        canRotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            ball.Rotate(new Vector3(0,0,rotationRate) * Time.deltaTime);   
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.ToLower().Contains("projectile"))
        {
            canRotate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.ToLower().Contains("projectile"))
        {
            canRotate = false;
        }
    }
}
