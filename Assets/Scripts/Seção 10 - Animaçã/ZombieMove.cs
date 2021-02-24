using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{

    [SerializeField] private Transform hero;
    
    [SerializeField] private float speed = 1.0f;

   
    
    private bool _isChasing = false;
    private float _dist;
    private bool _isFacingLeft = true;

    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _dist = Vector2.Distance(transform.position, hero.position);

        if ((hero.transform.position.x > transform.position.x) && _isFacingLeft)
            Flip();
        else if (hero.transform.position.x < transform.position.x && !_isFacingLeft)
            Flip();

        if (_isChasing && _dist > 2.8f)
        {
            if (hero.transform.position.x < transform.position.x)
            {
                transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
                _anim.SetBool("isWalking", true);
                _anim.SetBool("isIdle", false);
            }
            else if (hero.transform.position.x > transform.position.x)
            {
                transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                _anim.SetBool("isWalking", true);
                _anim.SetBool("isIdle", false);
            }
        }
        else
        {
            _anim.SetBool("isWalking", false);
            _anim.SetBool("isIdle", true);
        }
    }
    
    void Flip()
    {
        _isFacingLeft = !_isFacingLeft;
        Vector3 reflection = transform.localScale;
        reflection.x *= -1;
        transform.localScale = reflection;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isChasing = true;
        }
    }
}
