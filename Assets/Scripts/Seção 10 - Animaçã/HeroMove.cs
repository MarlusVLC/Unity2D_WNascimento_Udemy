using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float jumpForce = 6.5f;

    private bool _isFacingRight = true;
    private bool _canJump = false;
    private float _horVelocity;

    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.RightArrow) && !_isFacingRight)
        //     Flip();
        // else if (Input.GetKeyDown(KeyCode.LeftArrow) && _isFacingRight)
        // {
        //     Flip();
        // }
        
        if (((Input.GetAxisRaw("Horizontal") == 1) && !_isFacingRight) 
            ||  (Input.GetAxisRaw("Horizontal") == -1 && _isFacingRight))
            Flip();

        _horVelocity = speed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector2(_horVelocity, 0));

        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 reflection = transform.localScale;
        reflection.x *= -1;
        transform.localScale = reflection;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("floor"))
            _canJump = true;
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("floor"))
            _canJump = false;
    }
}
