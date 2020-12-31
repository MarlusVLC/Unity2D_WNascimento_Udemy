using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputs : MonoBehaviour
{

    public float moveRate = 10f;
    public float scaleRate = 1f;
    public GameObject ammo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    transform.position += new Vector3(0f, 0.1f);
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    transform.position += new Vector3(0f, -0.1f);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        //}








        //float H = Input.GetAxis("Horizontal") * moveRate;
        //float V = Input.GetAxis("Vertical") * moveRate;





        //float H = Input.GetAxis("Mouse X") * moveRate;
        //float V = Input.GetAxis("Mouse Y") * moveRate;

        //float H = Input.GetAxis("Fire1");
        //float V = Input.GetAxis("Fire2");

        //float H = Input.GetAxis("X360_A");
        //float V = Input.GetAxis("X360_B");

        float H = Input.GetAxis("X360_DPad_X") * moveRate;
        float V = -Input.GetAxis("X360_DPad_Y") * moveRate;

        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Instantiate(ammo, new Vector3(0,0,0), Quaternion.identity);
        //}

        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Instantiate(ammo, new Vector3(0, 0, 0), Quaternion.identity);
        }


        transform.Translate(new Vector3(H * Time.deltaTime, V * Time.deltaTime, 0));





        //float scale = Input.GetAxis("Mouse ScrollWheel");
        float scale = Input.GetAxis("X360_Triggers") * scaleRate;

        transform.localScale += new Vector3(scale, scale, 0);




    }
}
