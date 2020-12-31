using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceApp : MonoBehaviour
{
    public float force = 10f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (this.gameObject.tag.ToLower().Contains("normal".ToLower()))
        {
            force = 5f;
        } else if (this.gameObject.CompareTag("SUPERjump"))
        {
            force = 50f;
        }
        else
        {
            force = 0f; 
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
    }
}
