using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class HeroMoveUI : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;
    
    [SerializeField] private float walkingSpeed = 2.5f;
    [SerializeField] private float runningSpeed = 10f;
    [SerializeField] private float jumpForce = 6.5f;
    // [SerializeField] private float boostTimeLimit = 1.0f;

    private bool _isFacingRight = true;
    
    private bool _canJump = false;
    [SerializeField] private Transform _feet;
    [SerializeField] private LayerMask _whatIsFloor;
    [SerializeField] private float contactRadius = 0.2f;
    
    private bool _isAlive = true;
    private bool _isRunning = false;
    private bool _isShooting = false;
    // private bool _timeIsRunning = false;
    private float _speed;
    private float _horVelocity;
    private float _direction;
    // private float _boostTimer = 0f;

    private Animator _anim;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

    }

    void Update()
    {

        if (_isAlive)
        {
            //É CHÃO
            _canJump = Physics2D.OverlapCircle(_feet.position, contactRadius, _whatIsFloor);
            
            _direction = Input.GetAxisRaw("Horizontal");
            
            //Flip sprite
            if ((_direction > 0 && !_isFacingRight) || (_direction < 0 && _isFacingRight))
                Flip();
            
            //Walk to Idle and vice-versa
            if (Input.GetButton("Horizontal"))
            {
                if (Input.GetKey(KeyCode.LeftShift)  && !_isShooting)
                {
                    if (_canJump)
                        SetAnimParameter_X("isRunning");
                    else
                    {
                        SetAnimParameter_X("isWalking");
                    }
                    
                    _speed = runningSpeed;
                }
                else
                {
                    SetAnimParameter_X("isWalking");
                    _speed = walkingSpeed;
                }

            }
            else
            {
                SetAnimParameter_X("isIdle");
            }

            //Alter velocity
            _horVelocity = _speed * Time.deltaTime * _direction;
            transform.Translate(new Vector2(_horVelocity, 0));
            
            //Shoot
            if (_canJump && !_isRunning && Input.GetKey(KeyCode.Z))
            {
                SetAnimParameter_Y("isShooting");
            }
            else
            {
                _anim.SetBool("isShooting", false);
            }
            
            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && _canJump)
            {
                SetAnimParameter_Y("isJumping");
                _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            
            if (_rb.velocity.y > 0)
                SetAnimParameter_Y("isJumping");
            else if(_rb.velocity.y < 0)
                SetAnimParameter_Y("isFalling");


            
            //Scroll rawImage
            Rect rawRect = new Rect(rawImage.uvRect);
            rawRect.x = transform.position.x;
            rawRect.y = transform.position.y;
            rawImage.uvRect = rawRect;

        }
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
        if (other.gameObject.CompareTag("projectile"))
        {
            _isAlive = false;
            _anim.SetBool("isDying", !_isAlive);
        }
        else if (other.gameObject.CompareTag("floor"))
            SetAnimParameter_Y("None");

    }
    

    void SetAnimParameter_X(string parameter)
    {
        switch (parameter)
        {
            case "isIdle":
                _anim.SetBool("isWalking", false);
                _anim.SetBool("isRunning", false);
                _anim.SetBool("isIdle", true);
                _isRunning = false;
                break;
            case "isWalking":
                _anim.SetBool("isWalking", true);
                _anim.SetBool("isRunning", false);
                _anim.SetBool("isIdle", false);
                _isRunning = false;
                break;
            case "isRunning":
                _anim.SetBool("isWalking", false);
                _anim.SetBool("isRunning", true);
                _anim.SetBool("isIdle", false);
                _isRunning = true;
                break;
        }
    }

    void SetAnimParameter_Y(string parameter)
    {
        switch (parameter)
        {
            case "isShooting":
                _anim.SetBool("isShooting", true);
                _anim.SetBool("isJumping", false);
                _anim.SetBool("isFalling", false);
                break;
            case "isJumping":
                _anim.SetBool("isShooting", false);
                _anim.SetBool("isJumping", true);
                _anim.SetBool("isFalling", false);
                break;
            case "isFalling":
                _anim.SetBool("isShooting", false);
                _anim.SetBool("isJumping", false);
                _anim.SetBool("isFalling", true);
                break;
            default:
                _anim.SetBool("isShooting", false);
                _anim.SetBool("isJumping", false);
                _anim.SetBool("isFalling", false);
                break;
        }

        _isShooting = _anim.GetBool("isShooting");

    }

    // void SetRunningTimer()
    // {
    //     if (_boostTimer < boostTimeLimit && _timeIsRunning)
    //         _boostTimer += Time.deltaTime;
    //     else
    //     {
    //         _timeIsRunning = false;
    //         _boostTimer = 0;
    //     }
    // }
}

