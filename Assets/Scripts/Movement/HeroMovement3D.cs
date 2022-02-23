using UnityEngine;
using UnityEngine.UI;

namespace Movement
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class HeroMovement3D : MonoBehaviour
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
        private float moveHorizontal;
        private float moveVertical;
        private float moveModule;
        private int magnetItem = 0;
        private bool isShooting;

        private Animator anim;
        private Rigidbody heroiRB;


        void Start()
        {
            heroiRB = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            noChao = Physics.Raycast(noChaoCheck.position, Vector3.down, noChaoRaio, oQueEChao);
            
            //Idle
            anim.SetBool("isGrounded", noChao);
            
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");

            var movement = new Vector3(moveHorizontal,0, moveVertical);
            movement = movement.normalized * maxSpeed;
            heroiRB.velocity = new Vector3(movement.x, heroiRB.velocity.y, movement.z);

            anim.SetFloat("uHorizontalSpeed", Mathf.Abs(movement.magnitude)/maxSpeed);
            anim.SetFloat("verticalAcceleration", heroiRB.velocity.y);
            
            ///Tiro andando
            isShooting = Input.GetButton("Fire1");
            anim.SetBool("isShooting", isShooting);

            if (moveHorizontal > 0 && !face)
            {
                Flip ();
            }
            else if (moveHorizontal < 0 && face)
            {
                Flip ();
            }
        }

        private void Update()
        {
            if (noChao && Input.GetKeyDown(KeyCode.Space))
            {   
                heroiRB.AddForce(new Vector3(0, jumpForce,0));
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