using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Movement
{
    public class HeroMovement_William : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D heroiRB;
        [SerializeField] private float maxSpeed = 5f;
        [Header("UI")] 
        [SerializeField] private Text txtMagnet; 

        private bool face = true;

        private Animator anim;

        private bool noChao;
        private Transform noChaoCheck;
        private float noChaoRaio = 0.2f;
        private float jumpForce = 1000f;
        private float move;
        private int magnetItem = 0;

        void Start()
        {
            anim = GetComponent<Animator>();
        }
        
        
    }
}

