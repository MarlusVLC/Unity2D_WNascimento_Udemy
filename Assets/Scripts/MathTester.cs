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


        private Vector3 _point;
        private Vector2[] _squareVertices;
        
        private SpriteRenderer _spriteRenderer;
        
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            matrix1 = new Matrix(new float[2,2] {{1,1},{1,1}});
            matrix2 = new Matrix(new float[2, 2] {{2, 4}, {4, 3}});
            irregularMatrix = new Matrix(new float[1, 2] {{1, 2}});

            _point = Vector3.zero;
            
            _squareVertices = new Vector2[]
            {
                new Vector2(1, 1),
                new Vector2(-1,1),
                new Vector2(-1, -1),
                new Vector2(1,-1)
            };
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
                    // _matrixOperator.printMatrix(_matrixOperator.NullMatrix(5));
                    
                    // resultMatrix = _matrixOperator.Sum(matrix1, matrix2);
                    // _matrixOperator.printMatrix(resultMatrix);
                    // resultMatrix = matrix1 + matrix2;
                    // resultMatrix -= matrix2;
                    // resultMatrix.Print();
                    // Matrix.Null(5).Print();
                    // Matrix.Identity(5).Print();
                    // matrix1++;
                    // matrix1.Print();
                    // (2 * matrix1).Print();
                    // matrix2.SetColumn(irregularMatrix.GetRow(0),1);
                    // matrix2.Print();
                    (matrix1 * matrix2).Print();
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

                    VectorOperator.PTranslate(_squareVertices, tX, tY);
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

                    VectorOperator.PScale(_squareVertices, tX, tY);
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    // transform.position = _vector2Operator.RotateVector2(transform.position, theta);
                    // transform.position = transform.position.CRotate(theta);
                    
                    // for (int i = 0; i < _polygonVertices.Length; i++)
                    // {
                    //     _polygonVertices[i] = _polygonVertices[i].CRotate(theta);
                    // }

                    VectorOperator.PRotate(_squareVertices, theta);
                }

            }
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                // Gizmos.color = Color.red;
                // Gizmos.DrawSphere(_point, gizmoRadius);
                drawGizmoSquare(_squareVertices, Color.red, gizmoRadius);
            }
        }


        public void drawGizmoSquare(Vector2[] _polygonVertices, Color color, float iconRadius)
        {
            Gizmos.color = color;
            Gizmos.DrawSphere(_polygonVertices[0], iconRadius);
            Gizmos.DrawSphere(_polygonVertices[1], iconRadius);
            Gizmos.DrawSphere(_polygonVertices[2], iconRadius);
            Gizmos.DrawSphere(_polygonVertices[3], iconRadius);
            Gizmos.DrawLine(_polygonVertices[0],_polygonVertices[1]);
            Gizmos.DrawLine(_polygonVertices[1],_polygonVertices[2]);
            Gizmos.DrawLine(_polygonVertices[2],_polygonVertices[3]);
            Gizmos.DrawLine(_polygonVertices[3],_polygonVertices[0]);
        }
        
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