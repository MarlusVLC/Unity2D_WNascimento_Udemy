using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedJoint : MonoBehaviour
{
    private FixedJoint2D _fixedJoint;
    // Start is called before the first frame update
    void Awake()
    {
        _fixedJoint = GetComponent<FixedJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
