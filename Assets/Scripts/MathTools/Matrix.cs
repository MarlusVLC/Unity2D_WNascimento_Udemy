using System;
using UnityEngine;

namespace MathTools
{
    public class Matrix

    {
        public float[,] Inside;
        
        private int _height,_length;

        public Matrix(float[,] matrix0)
        {
            Inside = matrix0;
            _height = matrix0.GetLength(0);
            _length = matrix0.GetLength(1);
        }
        
        

        public static Matrix operator +(Matrix a, Matrix b)
            => new Matrix(MatrixOperator.getInstance().Sum(a.Inside, b.Inside));

        public static Matrix operator -(Matrix a, Matrix b)
            => new Matrix(MatrixOperator.getInstance().Subtract(a.Inside, b.Inside));

        public static Matrix operator *(Matrix a, float b)
            => new Matrix(MatrixOperator.getInstance().ScalarProduct(a.Inside, b));
        
        public static Matrix operator *(float b, Matrix a)
            => new Matrix(MatrixOperator.getInstance().ScalarProduct(a.Inside, b));
        
        public static Matrix operator *(Matrix a, Matrix b)
            => new Matrix(MatrixOperator.getInstance().CrossProduct(a.Inside, b.Inside));
        
        //public dotProduct
        
        
        public static Matrix operator ++(Matrix a)
        {
            if (a._height != a._length)
            {
                throw (new InequalMatricesException("Unitary operations require Matrices to have same length and height"));
            }
            return a + Matrix.Identity(a._height);
        }
        
        public static Matrix operator --(Matrix a)
        {
            if (a._height != a._length)
            {
                throw (new InequalMatricesException("Unitary operations require Matrices to have same length and height"));
            }
            return a - Matrix.Identity(a._height);
        }
        
        
        
        public static Matrix Null(int rowsAndColumns)
        {
            float[,] nullMatrix = new float[rowsAndColumns, rowsAndColumns];
            for (int i = 0; i < rowsAndColumns; i++)
            {
                for (int j = 0; j < rowsAndColumns; j++)
                {
                    nullMatrix.SetValue(0, i, j);
                }
            }

            return new Matrix(nullMatrix);
        }
        
        public static Matrix Identity(int rowsAndColumns)
        {
            float[,] nullMatrix = new float[rowsAndColumns, rowsAndColumns];
            for (int i = 0; i < rowsAndColumns; i++)
            {
                for (int j = 0; j < rowsAndColumns; j++)
                {
                    float input = i == j ? 1 : 0;
                    nullMatrix.SetValue(input, i, j);
                }
            }
            return new Matrix(nullMatrix);
        }
        
        
        public float[] GetRow(int rowIndex)
        {
            float[] row = new float[Inside.GetLength(1)];
            for (int j = 0; j < Inside.GetLength(1); j++)
            {
                row.SetValue(Inside.GetValue(rowIndex, j), j);
            }
            
            return row;
        }

        public void SetRow(float[] enuple, int rowIndex)
        {
            if (enuple.Length != _length)
                throw (new InequalMatricesException("The new row must have same dimension as the matrix's row length"));

            for (int i = 0; i < enuple.Length; i++)
            {
                Inside[rowIndex, i] = enuple[i];
            }
        }
        
        public float[] GetColumn(int columnIndex)
        {
            float[] column = new float[Inside.GetLength(0)];
            for (int i = 0; i < Inside.GetLength(0); i++)
            {
                column.SetValue(Inside.GetValue(i, columnIndex), i);
            }
            return column;
        }

        public void SetColumn(float[] enuple, int columnIndex)
        {
            if (enuple.Length != _height)
                throw (new InequalMatricesException("The new column must have same dimension as the matrix's column length"));

            for (int i = 0; i < enuple.Length; i++)
            {
                Inside[i, columnIndex] = enuple[i];
            }
        }
        
        
        //public Matrix GetRowMatrix
        //public Matrix GetColumnMatrix
        //public SetRow
        //public SetColumn
        
        
    
        public void Print()
        {
            String message = "\n";
            for (int i = 0; i < Inside.GetLength(0); i++)
            {
                for (int j = 0; j < Inside.GetLength(1); j++)
                {
                    message += Inside[i,j].ToString() + " ";
                }
                message += "\n";
            }
            Debug.Log(message);
        }

        public int Heigth => _height;
        public int Length => _length;

    }
}