using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuScript : MonoBehaviour
{

    /*
     * 
     * 
     * 
     * 
     */
    int numLives = 1484646;
    int numCoins = 10;
    string name = "morlon";
    float energy = 1.78f;
    //int[] nums = { 1, 2, 8888, 4 };
    //int[] nums = new int[4] { 0, 8, 9, 88 };
    //double[] nums = new double[4];
    //double[,] matriz = new double[5, 5];
    //double[,] matriz = { { 0, 1 }, { 9, 8, 7 } };
    //List<List<double>> matriz = new List<List<double>>();
    //Dictionary<int, string> carros = new Dictionary<int, string>();

    // Start is called before the first frame update
    void Start()
    {
        /*
         * LIST COLLECTION
        for (int i = 0; i < 5; i++)
        {
            List<double> subLista = new List<double>();
            for (int j = 0; j < 5; j++)
            {
                subLista.Add(0);
            }
            matriz.Add(subLista);   
        }

        string arraystring = " ";
        for (int i = 0; i < matriz.Count; i++)
        {
            for (int j = 0; j < matriz[0].Count; j++)
            {
                if (i == j)
                    matriz[i][j] = 1;
                arraystring += string.Format("{0} ", matriz[i][j]);
            }
            arraystring += System.Environment.NewLine;
        }
        Debug.Log(arraystring);

        print(matriz.Count);
        print(matriz[0].Count);
        */

        /*
         * DICTIONARY COLLECTION
        carros.Add(0, "Ford");
        carros.Add(1, "Chevrolet");

        foreach (int ID in carros.Keys)
        {
            print(carros[ID]);
        }

        print(carros);
        */

        //int a = 2;
        //int b = 1002;
        //Debug.Log("Soma: " + (int)(a + b));



    }

    // Update is called once per frame
    void Update()
    {

    }
}
