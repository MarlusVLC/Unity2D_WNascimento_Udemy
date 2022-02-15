using System;
using Unity.Mathematics;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(BoxCollider))]
    public class HeroMovement : MonoBehaviour
    {
        // [SerializeField] Rigidbody2D heroiRB;
        [SerializeField] private Rigidbody heroiRB;
        [SerializeField] private float maxSpeed = 5f;
        
        [SerializeField] private Animator anim;

        [SerializeField] private bool noChao;
        [SerializeField] private Transform noChaoCheck;
        [SerializeField] private float noChaoRaio = 0.3f;
        [SerializeField] private LayerMask oQueEChao;
        [SerializeField] private float jumpForce = 1000f;
        [SerializeField] private float moveHorizontal;
        [SerializeField] private float moveVertical;

        private SpriteRenderer sprite;

        void Start()
        {
            anim = GetComponent<Animator>();
            heroiRB = GetComponent<Rigidbody>();
            sprite = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            // noChao = Physics2D.OverlapCircle(noChaoCheck.position, noChaoRaio, oQueEChao);
            noChao = Physics.Raycast(noChaoCheck.position, Vector3.down, noChaoRaio, oQueEChao);
            
  
            
            //Pulo
            anim.SetBool("isJumping", !noChao );

            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(heroiRB.velocity.x) > 0.01f)
            {
                anim.SetBool("isWalking", Mathf.Abs(moveHorizontal) > 0.1f);
            }

            if (Mathf.Abs(heroiRB.velocity.y) > 0.01f)
            {
                anim.SetBool("isWalking", Mathf.Abs(moveVertical) > 0.1f);
            }

            //Idle
            anim.SetBool("isIdle", noChao && Mathf.Abs(moveHorizontal) < 0.1f && Mathf.Abs(moveVertical) < 0.1f);
            
            heroiRB.velocity = new Vector3(moveHorizontal * maxSpeed, heroiRB.velocity.y, moveVertical * 2 * maxSpeed);

            if (moveHorizontal > 0 && sprite.flipX)
            {
                sprite.flipX = false;
            }
            else if (moveHorizontal < 0)
            {
                sprite.flipX = true;
            }
        }
    }
}