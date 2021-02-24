using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceJointBreak : MonoBehaviour
{
    private DistanceJoint2D distJoint;

    // Start is called before the first frame update
    void Start()
    {
        distJoint = GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            distJoint.breakForce = 1;
        }
    }
}
