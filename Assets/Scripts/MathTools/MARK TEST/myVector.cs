using System;
using UnityEngine;

namespace MathTools
{
    public  class myVector
    {
        public float[] Array;

        private int _length;

        public myVector(float[] array)
        {
            Array = array;
            _length = array.Length;
        }

        public static myVector operator +(myVector a, myVector b)
        {
            if (a._length != b._length)
                throw new InequalVectorsException("Vectors should have same length");
            float[] newVector = new float[a._length];
            for (int i = 0; i < newVector.Length; i++)
            {
                newVector[i] = a.Array[i] + b.Array[i];
            }

            return new myVector(newVector);
        }
        
        public static myVector operator -(myVector a, myVector b)
        {
            if (a._length != b._length)
                throw new InequalVectorsException("Vectors should have same length");
            float[] newVector = new float[a._length];
            for (int i = 0; i < newVector.Length; i++)
            {
                newVector[i] = a.Array[i] - b.Array[i];
            }

            return new myVector(newVector);
        }
        
        
        public static myVector operator *(myVector a, float k)
        {
            float[] newVector = new float[a._length];
            for (int i = 0; i < newVector.Length; i++)
            {
                newVector[i] = a.Array[i]*k;
            }
            return new myVector(newVector);
        }

        public float Magnitude()
        {
            float result = 0;
            foreach (float element in Array)
            {
                result += (element * element);
            }

            result = Mathf.Sqrt(result);
            return result;
        }


        public void Normalize()
        {
            float magnitude = Magnitude();
            for (int i = 0; i < _length; i++)
            {
                Array[i] /= magnitude;
            }
        }
        

        public void Print()
        {
            String message = "";
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                message += Array[i].ToString() + " ";
            }
            Debug.Log(message);
        }
        
        
    }
    
    public class InequalVectorsException : Exception
    {
        public InequalVectorsException(string message) : base(message)
        {
        }
    }

}