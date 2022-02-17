using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class BaseHeroMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] protected float maxSpeed = 5f;
        [SerializeField] protected float jumpForce = 500f;
        
        [Header("UI")] 
        [SerializeField] protected Text txtMagnet;

        [Header("Ground detection")] 
        [SerializeField] protected LayerMask oQueEChao;
        [SerializeField] protected Transform noChaoCheck;
        [SerializeField] protected float noChaoRaio = 2f;

        protected bool face = true;
        protected bool noChao;
        protected float move;
        protected int magnetItem = 0;

        protected Animator anim;
        protected Rigidbody2D heroiRB;


        void Start()
        {
            heroiRB = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            noChao = Physics2D.OverlapCircle(noChaoCheck.position, noChaoRaio, oQueEChao);
            
            //Idle
            anim.SetBool("Idle", noChao);
            
            //Pulo
            anim.SetBool("Jump", !noChao);

            move = Input.GetAxis("Horizontal");
            
            anim.SetFloat("Walk", Mathf.Abs(move));

            heroiRB.velocity = new Vector2(move * maxSpeed, heroiRB.velocity.y);
            
            ///Tiro andando
            float tiroParado = Input.GetAxis("Fire1");

            if (tiroParado >= 1 && Mathf.Abs(move) > 0.1f)
            {
                anim.SetBool("WalkNShot", true);
                anim.SetBool("StopShot", false);
            }
            else if (tiroParado >= 1 && Mathf.Abs(move) < 0.01f)
            {
                anim.SetBool("WalkNShot", false);
                anim.SetBool("StopShot", true);
            }
            
            //Tiro parado
            else if (tiroParado >= 1)
            {
                anim.SetBool("StopShot", true);
            }
            else if (tiroParado <= 0)
            {
                anim.SetBool("StopShot", false);
            }
            
            ////////////////////////////////////////////////////////////////

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
                anim.SetBool("Idle", false);
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

