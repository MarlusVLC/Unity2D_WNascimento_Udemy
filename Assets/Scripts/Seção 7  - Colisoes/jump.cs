using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public float force = 500f;
    // public bool canJump = false;
    public int numberOfJumps = 2;
    public AudioClip jumpSfx;
    
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (numberOfJumps > 0)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Z))
            {
                AudioManager.getInstance.PlayAudio(jumpSfx);
                rb.AddForce(new Vector2(0,force * Time.deltaTime), ForceMode2D.Impulse);
                numberOfJumps--;
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.ToLower().Contains("floor"))
        {
            numberOfJumps = 2;
            // canJump = true;
        }
    }

    // void OnCollisionExit2D(Collision2D other)
    // {
    //     if (other.gameObject.tag.ToLower().Contains("floor"))
    //     {
    //         canJump = false;
    //     }
    // }
}
