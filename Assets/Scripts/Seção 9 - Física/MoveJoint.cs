using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoint : MonoBehaviour
{

    [SerializeField] SliderJoint2D slider;
    private JointMotor2D _motor;
    // private Effector2D _effector2D2D;
    // private Joint2D _joint2D;
    // private ConstantForce2D _force2D;
    
    
    void Awake()
    {
        slider = GetComponent<SliderJoint2D>();
        _motor = slider.motor;
    }

    
    void Update()    
    {

        if (slider.limitState == JointLimitState2D.UpperLimit) 
        {
            _motor.motorSpeed = -1;
            slider.motor = _motor;
        }
        else if (slider.limitState == JointLimitState2D.LowerLimit)
        {
            _motor.motorSpeed = 1;
            slider.motor = _motor;
        }
        
    }
}
