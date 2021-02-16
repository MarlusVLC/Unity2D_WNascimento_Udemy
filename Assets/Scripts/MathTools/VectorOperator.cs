using UnityEngine;

namespace MathTools
{
    public static class VectorOperator
    {

        /// <summary>
        /// <para>add tX and tY units to a single 2D vector</para>
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="tX"></param>
        /// <param name="tY"></param>
        /// <returns></returns>
        public static Vector2 STranslate(this Vector2 origin, float tX, float tY)
        {
            float[,] vector2Matrix = new float[1, 3] {  {origin.x ,  origin.y ,  1}  };
            float[,] transformationMatrix = new float[3, 3]
            {
                {1, 0, 0},
                {0, 1, 0},
                {tX, tY, 1}
            };
            float[,] newVector2Matrix = MatrixOperator.getInstance().CrossProduct(vector2Matrix, transformationMatrix);
            return new Vector2(newVector2Matrix[0, 0], newVector2Matrix[0, 1]);
        }
        
        /// <summary>
        /// <para>add tX,tY and tZ units to a single 3D vector</para>
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="tX"></param>
        /// <param name="tY"></param>
        /// <param name="tZ"></param>
        /// <returns></returns>
        public static Vector3 STranslate(this Vector3 origin, float tX, float tY, float tZ)
        {
            float[,] vector2Matrix = new float[1, 4] {  {origin.x ,  origin.y ,  origin.z, 1}  };
            float[,] transformationMatrix = new float[4, 4]
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {tX, tY, tZ, 1}
            };
            float[,] newVector3Matrix = MatrixOperator.getInstance().CrossProduct(vector2Matrix, transformationMatrix);
            return new Vector3(newVector3Matrix[0, 0], newVector3Matrix[0, 1], newVector3Matrix[0,2]);
        }

        public static void PTranslate(in Vector2[] _polygonVertices, float tX, float tY)
        {
            for (int i = 0; i < _polygonVertices.Length; i++)
            {
                _polygonVertices[i] = _polygonVertices[i].STranslate(tX, tY);
            }
        }
        
        public static void PTranslate(in Vector3[] _polygonVertices, float tX, float tY, float tZ)
        {
            for (int i = 0; i < _polygonVertices.Length; i++)
            {
                _polygonVertices[i] = _polygonVertices[i].STranslate(tX, tY, tZ);
            }
        }

        public static Vector2 SScale(this Vector2 origin, float sX, float sY)
        {
            float[,] vector2Matrix = new float[1, 3] {{origin.x, origin.y, 1}};
            float[,] transformationMatrix = new float[3, 3]
            {
                {sX, 0, 0},
                {0, sY, 0},
                {0,  0, 1}
            };
            float[,] newVector2Matrix = MatrixOperator.getInstance().CrossProduct(vector2Matrix, transformationMatrix);
            return new Vector2(newVector2Matrix[0, 0], newVector2Matrix[0, 1]);
        }
                
        public static Vector3 SScale(this Vector3 origin, float sX, float sY, float sZ)
        {
            float[,] vector2Matrix = new float[1, 4] {{origin.x, origin.y, origin.z, 1}};
            float[,] transformationMatrix = new float[4, 4]
            {
                {sX, 0, 0, 0},
                {0, sY, 0, 0},
                {0, 0, sZ, 0},
                {0, 0, 0,  1}
            };
            float[,] newVector3Matrix = MatrixOperator.getInstance().CrossProduct(vector2Matrix, transformationMatrix);
            return new Vector3(newVector3Matrix[0, 0], newVector3Matrix[0, 1], newVector3Matrix[0,2]);
        }
        
        public static void PScale(in Vector2[] _polygonVertices, float tX, float tY)
        {
            for (int i = 0; i < _polygonVertices.Length; i++)
            {
                _polygonVertices[i] = _polygonVertices[i].SScale(tX, tY);
            }
        }
        
        public static void PScale(in Vector3[] _polygonVertices, float tX, float tY, float tZ)
        {
            for (int i = 0; i < _polygonVertices.Length; i++)
            {
                _polygonVertices[i] = _polygonVertices[i].SScale(tX, tY, tZ);
            }
        }
        
        public static Vector2 SRotate(this Vector2 origin, float theta)
        {
            theta *= Mathf.Deg2Rad;
            float[,] vector2Matrix = new float[1, 3] {{origin.x, origin.y, 1}};
            float[,] transformationMatrix = new float[3, 3]
            {
                {Mathf.Cos(theta),  Mathf.Sin(theta), 0},
                {-Mathf.Sin(theta), Mathf.Cos(theta), 0},
                {0               ,  0                ,1}
            };
            float[,] newVector2Matrix = MatrixOperator.getInstance().CrossProduct(vector2Matrix, transformationMatrix);
            return new Vector2(newVector2Matrix[0, 0], newVector2Matrix[0, 1]);
        }
        
        public static Vector3 SRotate(this Vector3 origin, float theta)
        {
            theta *= Mathf.Deg2Rad;
            float[,] vector2Matrix = new float[1, 4] {{origin.x, origin.y, origin.z, 1}};
            float[,] transformationMatrix = new float[4, 4]
            {
                {Mathf.Cos(theta),  Mathf.Sin(theta), 0, 0},
                {-Mathf.Sin(theta), Mathf.Cos(theta), 0, 0},
                {0               , 0                , 1, 0},
                {0               , 0                , 0, 0}
            };
            float[,] newVector3Matrix = MatrixOperator.getInstance().CrossProduct(vector2Matrix, transformationMatrix);
            return new Vector3(newVector3Matrix[0, 0], newVector3Matrix[0, 1], newVector3Matrix[0,2]);
        } 
        
        public static void PRotate(in Vector2[] _polygonVertices, float theta)
        {
            for (int i = 0; i < _polygonVertices.Length; i++)
            {
                _polygonVertices[i] = _polygonVertices[i].SRotate(theta);
            }
        }
        
        public static void PRotate(in Vector3[] _polygonVertices, float theta)
        {
            for (int i = 0; i < _polygonVertices.Length; i++)
            {
                _polygonVertices[i] = _polygonVertices[i].SRotate(theta);
            }
        }
    }
}
    
    
    
