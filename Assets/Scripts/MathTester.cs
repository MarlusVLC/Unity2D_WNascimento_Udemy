using System;
using System.Numerics;
using UnityEngine;
using MathTools;
using UnityEditor;
using UnityEditor.U2D.Path;
using Matrix4x4 = UnityEngine.Matrix4x4;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace DefaultNamespace
{
    public class MathTester : MonoBehaviour
    {
        [SerializeField] private Matrix matrix1;
        [SerializeField] private Matrix matrix2;
        [SerializeField] private Matrix matrix3;
        [SerializeField] private Matrix resultMatrix;
        [SerializeField] private Matrix irregularMatrix;
        [SerializeField] private Vector2 testVector2;
        [SerializeField] private Vector3 testVector3;
        [SerializeField] private float tX;
        [SerializeField] private float tY;
        [SerializeField] private float tZ;
        [SerializeField] private float sX;
        [SerializeField] private float sY;
        [SerializeField] private float sZ;
        [SerializeField] private float theta;
        [SerializeField] private float gizmoRadius;


        [SerializeField] private myVector newVectorA;
        [SerializeField] private myVector newVectorB;

        
        private Vector3 _point;
        private Vector2[] _squareVertices;
        
        private SpriteRenderer _spriteRenderer;
        
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            matrix1 = new Matrix(new float[2,2] {{1,2},{1,-4}});
            matrix2 = new Matrix(new float[3, 3] {{2, 4, 5}, {4, 3, 9}, {9, 9, 9}});
            matrix3 = new Matrix(new float[4, 4] {{1,2,3,4}, {2,-3,4,5}, {3,4,5,6}, {4,5,-6,7}});
            irregularMatrix = new Matrix(new float[1, 2] {{1, 2}});

            _point = Vector3.zero;
            
            _squareVertices = new Vector2[]
            {
                new Vector2(1, 1),
                new Vector2(-1,1),
                new Vector2(-1, -1),
                new Vector2(1,-1)
            };


            // float[,] array0 = new float[3, 3];
            // float[] subArray0 = new float[3] {0, 0, 0};
            // // array0[1] = subArray0;
            // array0.SetValue(subArray0, 1);

            newVectorA = new myVector(new float[3] {1,1,1});
            newVectorB = new myVector(new float[3] {2,2,2});

        }

        private void Start()
        {

        }

        private void Update()
        {

            
            
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    // matrix1.Print();
                    // Debug.Log(matrix1.IsSingular());
                    // matrix1.InverseMatrix().Print();
                    // (matrix1 * matrix1.InverseMatrix()).Print();
                    //
                    // matrix2.Print();
                    // Debug.Log(matrix2.IsSingular());
                    // matrix2.InverseMatrix().Print();
                    // (matrix2 * matrix2.InverseMatrix()).Print();
                    //
                    // matrix3.Print();
                    // Debug.Log(matrix3.IsSingular());
                    // matrix3.InverseMatrix().Print();
                    // (matrix3 * matrix3.InverseMatrix()).Print();
                    //
                    // (matrix1 + matrix1 + matrix1).Print();
                    (newVectorA + newVectorB).Print();
                    print(newVectorA.Magnitude());
                    newVectorA.Normalize();
                    newVectorA.Print();
                    print(newVectorA.Magnitude());

                }

                else if (Input.GetKeyDown(KeyCode.T))
                {
                    // testVector2 = testVector2.Translate(tX,tY);
                    // testVector2.Translate(tX,tY, tZ);
                    // transform.position = transform.position.CTranslate(tX, tY, tZ);

                    // for (int i = 0; i < _polygonVertices.Length; i++)
                    // {
                    //     _polygonVertices[i] = _polygonVertices[i].CTranslate(tX, tY);
                    // }
                    
                    // _point.STranslate(tX,tY,tZ);

                    // VectorOperator.PTranslate(_squareVertices, tX, tY);
                    _point = _point.STranslate(tX, tY, tZ);

                }

                else if (Input.GetKeyDown(KeyCode.S))
                {
                    // transform.position = _vector2Operator.ScaleVector2(transform.position, sX, sY);
                    // transform.position = transform.position.CScale(sX, sY, sZ);
                    // transform.localScale = transform.localScale.CScale(sX, sY, sZ);
                    
                    // for (int i = 0; i < _polygonVertices.Length; i++)
                    // {
                    //     _polygonVertices[i] = _polygonVertices[i].CScale(sX, sY);
                    // }

                    VectorOperator.PScale(_squareVertices, sX, sY);
                }
                else if (Input.GetKey(KeyCode.R))
                {
                    // transform.position = _vector2Operator.RotateVector2(transform.position, theta);
                    // transform.position = transform.position.CRotate(theta);
                    
                    // for (int i = 0; i < _polygonVertices.Length; i++)
                    // {
                    //     _polygonVertices[i] = _polygonVertices[i].CRotate(theta);
                    // }

                    VectorOperator.PRotate(ref _squareVertices, theta);
                }

            }
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                // Gizmos.color = Color.red;
                // Gizmos.DrawSphere(_point, gizmoRadius);
                DrawGizmoSquare(_squareVertices, Color.red, gizmoRadius);
            }
        }


        public void DrawGizmoSquare(Vector2[] _polygonVertices, Color color, float iconRadius)
        {
            Gizmos.color = color;
            Gizmos.DrawSphere(new Vector2(_point.x+_polygonVertices[0].x, _point.y+_polygonVertices[0].y), iconRadius);
            Gizmos.DrawSphere(new Vector2(_point.x+_polygonVertices[1].x, _point.y+_polygonVertices[1].y), iconRadius);
            Gizmos.DrawSphere(new Vector2(_point.x+_polygonVertices[2].x, _point.y+_polygonVertices[2].y), iconRadius);
            Gizmos.DrawSphere(new Vector2(_point.x+_polygonVertices[3].x, _point.y+_polygonVertices[3].y), iconRadius);
            
            Gizmos.DrawLine(new Vector2(_point.x+_polygonVertices[0].x, _point.y+_polygonVertices[0].y),
                new Vector2(_point.x+_polygonVertices[1].x, _point.y+_polygonVertices[1].y));
            
            Gizmos.DrawLine(new Vector2(_point.x+_polygonVertices[1].x, _point.y+_polygonVertices[1].y),
                new Vector2(_point.x+_polygonVertices[2].x, _point.y+_polygonVertices[2].y));
            
            Gizmos.DrawLine(new Vector2(_point.x+_polygonVertices[2].x, _point.y+_polygonVertices[2].y),
                new Vector2(_point.x+_polygonVertices[3].x, _point.y+_polygonVertices[3].y));
            
            Gizmos.DrawLine(new Vector2(_point.x+_polygonVertices[3].x, _point.y+_polygonVertices[3].y),
                new Vector2(_point.x+_polygonVertices[0].x, _point.y+_polygonVertices[0].y));        }
        
        // public void drawGizmoCube(Vector3[] vertices, Color color, float iconRadius)
        // {
        //     Gizmos.color = color;
        //     Gizmos.DrawSphere(_polygonVertices[0], iconRadius);
        //     Gizmos.DrawSphere(_polygonVertices[1], iconRadius);
        //     Gizmos.DrawSphere(_polygonVertices[2], iconRadius);
        //     Gizmos.DrawSphere(_polygonVertices[3], iconRadius);
        //     
        //     Gizmos.DrawLine(_polygonVertices[0],_polygonVertices[1]);
        //     Gizmos.DrawLine(_polygonVertices[1],_polygonVertices[2]);
        //     Gizmos.DrawLine(_polygonVertices[2],_polygonVertices[3]);
        //     Gizmos.DrawLine(_polygonVertices[3],_polygonVertices[0]);
        // }
        
        
    }
}   