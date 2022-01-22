using System;
using UnityEngine;

namespace MathTools
{
    public class Vector3Operator : MonoBehaviour
    {
        public Vector3 VectorSum(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        
        public Vector3 VectorSub(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public Vector3 ScalarProd(Vector3 a, float k)
        {
            return new Vector3(a.x * k, a.y * k, a.z * k);
        }

        public float VectorMag(Vector3 a)
        {
            return Mathf.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
        }

        public Vector3 UnitVector3(Vector3 a)
        {
            return new Vector3(a.x / VectorMag(a), a.y / VectorMag(a), a.z / VectorMag(a));
        }


        [SerializeField] Vector3 a = new Vector3(1, 1, 1);
        [SerializeField] Vector3 b = new Vector3(1, 1, 1);
        [SerializeField] private float k = 3;


        private void Start()
        {
            
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    Debug.Log(VectorSum(a,b));
                    Debug.Log(VectorSub(a,b));
                    Debug.Log(ScalarProd(a,k));
                    Debug.Log(VectorMag(a));
                    Debug.Log(UnitVector3(a));
                }
            }
        }
    }
    
    
    
}