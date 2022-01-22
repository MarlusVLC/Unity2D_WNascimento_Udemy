using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    ATTACK, 
    PATROL, 
    RUN
};



public class nu2Script : MonoBehaviour
{
    Vehicle auto;
    Car viper;

    // Start is called before the first frame update
    void Start()
    {
        /* ENUM
        State currentState = State.PATROL;

        Debug.Log("o estado atual é: " + currentState);
        Debug.Log("seu valor é: " + (int)currentState);
        Debug.Log("o próximo estado é: " + (State)(int)(currentState + 1));
        */
        //Vehicle num0 = new Vehicle(3,"gasolina", false);
        //Debug.Log(Vehicle.getNumWheels());

        auto = new Vehicle();
        viper = new Car();
        viper.NumRodas = -4;
        Debug.Log(viper.NumRodas);

        viper.IsAuto = !viper.IsAuto;
        Debug.Log(viper.IsAuto);

        auto.goTo("aRuba");
        viper.goTo("miAme");
    }

    // Update is called once per frame
    void Update()
    {

    }


}


public class Vehicle : MonoBehaviour
{
    protected int numWheels = 5;
    protected string combustiveType;
    protected bool isAuto;


    //public Vehicle(int numWheels, string combustiveType, bool isAuto)
    //{
    //    this.combustiveType = combustiveType;
    //    this.isAuto = isAuto;
    //}


    public int NumRodas
    {
        get { return numWheels;  }
        set { if (value < 0)
                {
                    numWheels = 0;
                } 
                else
                {
                    numWheels = value;
                }
            }
    }

    public void goTo(string destination)
    {
        Debug.Log("Going to " + destination);
    }
}

public class Car : Vehicle
{
    
    
    public bool IsAuto
    {
        get { return isAuto; }
        set { isAuto = value; }
    }

    public int baseWheels
    {
        get { return base.numWheels; }
    }


    // public void goTo(string destination)
    // {
    //     Debug.Log("Getting rom" + destination);
    // }
}




