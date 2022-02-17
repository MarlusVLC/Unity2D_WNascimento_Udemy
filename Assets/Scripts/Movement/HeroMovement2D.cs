using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class HeroMovement2D : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float maxSpeed = 5f;
        [SerializeField] private float jumpForce = 500f;
        
        [Header("UI")] 
        [SerializeField] private Text txtMagnet;

        [Header("Ground detection")] 
        [SerializeField] private LayerMask oQueEChao;
        [SerializeField] private Transform noChaoCheck;
        [SerializeField] private float noChaoRaio = 2f;

        private bool face = true;
        private bool noChao;
        private float move;
        private int magnetItem = 0;
        private bool isShooting;

        private Animator anim;
        private Rigidbody2D heroiRB;


        void Start()
        {
            heroiRB = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            noChao = Physics2D.OverlapCircle(noChaoCheck.position, noChaoRaio, oQueEChao);
            
            //Idle
            anim.SetBool("isGrounded", noChao);
            
            move = Input.GetAxis("Horizontal");
            
            anim.SetFloat("uHorizontalSpeed", Mathf.Abs(move));
            anim.SetFloat("verticalAcceleration", heroiRB.velocity.y);

            heroiRB.velocity = new Vector2(move * maxSpeed, heroiRB.velocity.y);
            
            ///Tiro andando
            isShooting = Input.GetButton("Fire1");
            anim.SetBool("isShooting", isShooting);

            if (move > 0 && !face)
            {
                Flip ();
            }
            else if (move < 0 && face)
            {
                Flip ();
            }
        }

        private void Update()
        {
            if (noChao && Input.GetKeyDown(KeyCode.Space))
            {
                heroiRB.AddForce(new Vector2(0, jumpForce));
            }
        }

        void Flip()
        {
            face = !face;
            Vector3 tempScale = transform.localScale;
            tempScale.x *= -1;
            transform.localScale = tempScale;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("coin"))
            {
                magnetItem++;
                if (txtMagnet != null) txtMagnet.text = magnetItem.ToString();
                Destroy(other.gameObject);
            }
        }
    }
}

