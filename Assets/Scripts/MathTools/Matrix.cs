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
            => new Matrix(MatrixOperator.Sum(a.Inside, b.Inside));

        public static Matrix operator -(Matrix a, Matrix b)
            => new Matrix(MatrixOperator.Subtract(a.Inside, b.Inside));

        public static Matrix operator *(Matrix a, float b)
            => new Matrix(MatrixOperator.ScalarProduct(a.Inside, b));
        
        public static Matrix operator *(float b, Matrix a)
            => new Matrix(MatrixOperator.ScalarProduct(a.Inside, b));
        
        public static Matrix operator *(Matrix a, Matrix b)
            => new Matrix(MatrixOperator.CrossProduct(a.Inside, b.Inside));
        
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

        public Matrix GetRowMatrix(int rowIndex)
        {
            float[,] row = new float[1, Inside.GetLength(1)];
            for (int j = 0; j < Inside.GetLength(1); j++)
            {
                row[0, j] = Inside[rowIndex, j];
            }
            
            return new Matrix(row);
        }
        
        public Matrix GetColumnMatrix(int columnIndex)
        {
            float[,] column = new float[Inside.GetLength(0),1];
            for (int i = 0; i < Inside.GetLength(0); i++)
            {
                column[i, 0] = Inside[i, columnIndex];
            }
            return new Matrix(column);
        }


        public Matrix GetMinorMatrix(int row, int column)
        {
            float[,] minor = new float[Inside.GetLength(0)-1, Inside.GetLength(1)-1];
            int minorRow = 0;
            for (int i = 0; i < Inside.GetLength(0); i++)
            {
                if (i != row)
                {
                    int minorColumn = 0;
                    for (int j = 0; j < Inside.GetLength(1); j++)
                    {
                        if (j != column)
                        {
                            minor[minorRow, minorColumn] = Inside[i, j];
                            minorColumn++;
                        }
                    }

                    minorRow++;
                }
            }

            return new Matrix(minor);
        }

        public float Determinant()
        {
            if (Inside.GetLength(0) != Inside.GetLength(1))
                throw (new InequalMatricesException("Only square matrices have determinants"));
            if (Inside.Length == 2)
                return Inside[0, 0] * Inside[1, 1] - Inside[0, 1] * Inside[1, 0];
            else if (Inside.Length == 1)
            {
                return Inside[0, 0];
            }
            else
            {
                float determinant = 0;
                for (int i = 0; i < Inside.GetLength(1); i++)
                {
                    int cofSign = i % 2 == 0 ? 1 : -1;
                    determinant += cofSign * Inside[0, i] * GetMinorMatrix(0,i).Determinant();
                }

                return determinant;
            }
        }

        public Matrix MinorsMatrix()
        {
            float[,] minorsMatrix = new float[Inside.GetLength(0), Inside.GetLength(1)];
            for (int i = 0; i < Inside.GetLength(0); i++)
            {
                for (int j = 0; j < Inside.GetLength(1); j++)
                {
                    minorsMatrix[i, j] = GetMinorMatrix(i, j).Determinant();
                }
            }

            return new Matrix(minorsMatrix);
        }

        public Matrix CofactorMatrix()
        {
            float[,] cofMatrix = new float[Inside.GetLength(0), Inside.GetLength(1)];
            int cofSign = 1;
            for (int i = 0; i < Inside.GetLength(0); i++)
            {
                for (int j = 0; j < Inside.GetLength(1); j++)
                {
                    cofSign = (i + j) % 2 == 0 ? 1 : -1;
                    cofMatrix[i, j] = cofSign * GetMinorMatrix(i, j).Determinant();
                }
            }

            return new Matrix(cofMatrix);
        }

        public Matrix TransposeMatrix()
        {
            float[,] transMatrix = new float[Inside.GetLength(0), Inside.GetLength(1)];
            for (int i = 0; i < Inside.GetLength(0); i++)
            {
                for (int j = 0; j < Inside.GetLength(1); j++)
                {
                    transMatrix[i, j] = Inside[j, i];
                }
            }

            return new Matrix(transMatrix);
        }

        public Matrix AdjointMatrix()
        {
            float[,] adjMatrix = new float[Inside.GetLength(0), Inside.GetLength(1)];
            int cofSign = 1;
            for (int i = 0; i < Inside.GetLength(0); i++)
            {
                for (int j = 0; j < Inside.GetLength(1); j++)
                {
                    cofSign = (i + j) % 2 == 0 ? 1 : -1;
                    adjMatrix[j, i] = cofSign * GetMinorMatrix(i, j).Determinant();
                }
            }
            return new Matrix(adjMatrix);
        }

        public bool IsSingular()
        {
            return Determinant() == 0;
        }

        public Matrix InverseMatrix()
        {
            if (IsSingular())
                throw new InequalMatricesException("The matrix must have a determinant different than zero");
            return (1 / Determinant()) * AdjointMatrix();
        }
        
    
        public override string ToString()
        {
            String message = "\n";
            for (int i = 0; i < Inside.GetLength(0); i++)
            {
                for (int j = 0; j < Inside.GetLength(1); j++)
                {
                    message += Inside[i,j] + " ";
                }
                message += "\n";
            }

            return message;
        }

        public int Heigth => _height;
        public int Length => _length;

    }
}