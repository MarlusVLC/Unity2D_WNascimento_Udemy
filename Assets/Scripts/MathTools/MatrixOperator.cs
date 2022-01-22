using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Matrix4x4 = UnityEngine.Matrix4x4;
using Object = UnityEngine.Object;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace MathTools
{
	public static class MatrixOperator
	{


		public static float[,] Sum(float[,] matrix1, float[,] matrix2)
		{
			if (matrix1.GetLength(0) != matrix2.GetLength(0) ||
			    matrix1.GetLength(1) != matrix2.GetLength(1))
			{
				throw (new InequalMatricesException("Cardinal operations requires matrices with equal dimensions"));
			}
			else
			{
				float[,] resultMatrix = new float[matrix1.GetLength(0), matrix1.GetLength(1)];
				for (int i = 0; i < matrix1.GetLength(0); i++)
				{
					for (int j = 0; j < matrix1.GetLength(1); j++)
					{
						resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
					}
				}

				return resultMatrix;
			}
		}

		// public float[,] Sum(params Matrix[] matrices)
		// {
		//  if (matrix1.GetLength(0) != matrix2.GetLength(0) ||
		//      matrix1.GetLength(1) != matrix2.GetLength(1))
		//  {
		//   throw (new InequalMatricesException("Cardinal operations requires matrices with equal dimensions"));
		//  }
		//  else
		//  {
		//   float[,] resultMatrix = new float[matrix1.GetLength(0), matrix1.GetLength(1)];
		//   for (int i = 0; i < matrix1.GetLength(0); i++)
		//   {
		//    for (int j = 0; j < matrix1.GetLength(1); j++)
		//    {
		//     resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
		//    }
		//   }
		//   return resultMatrix;
		//  }
		// }

		public static float[,] Subtract(float[,] matrix1, float[,] matrix2)
		{
			if (matrix1.GetLength(0) != matrix2.GetLength(0) ||
			    matrix1.GetLength(1) != matrix2.GetLength(1))
			{
				throw (new InequalMatricesException("Cardinal operations requires matrices with equal dimensions"));
			}
			else
			{
				float[,] resultMatrix = new float[matrix1.GetLength(0), matrix1.GetLength(1)];
				for (int i = 0; i < matrix1.GetLength(0); i++)
				{
					for (int j = 0; j < matrix1.GetLength(1); j++)
					{
						resultMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
					}
				}

				return resultMatrix;
			}
		}


		public static float[,] ScalarProduct(float[,] matrix, float scalar)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					matrix[i, j] *= scalar;
				}
			}

			return matrix;
		}



		// float[,] matrix0 = new float[2, 2] { { 0, 1 }, { 2, 3 } };
		// float[,] matrix1 = new float[2, 2] { { 0, 1 }, { 2, 3 } };

		public static float[] getRow(int i, float[,] matrix)
		{
			float[] row = new float[matrix.GetLength(1)];
			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				row.SetValue(matrix.GetValue(i, j), j);
			}

			return row;
		}

		/// <summary>
		/// <para> Deprecated method. Prefer to use and edit Matrix.cs method instead</para>
		/// </summary>
		public static float[] getColumn(int j, float[,] matrix)
		{
			float[] column = new float[matrix.GetLength(0)];
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				column.SetValue(matrix.GetValue(i, j), i);
			}

			return column;
		}


		public static float DotProduct(float[] tuple1, float[] tuple2)
		{
			if (tuple1.Length != tuple2.Length)
				throw (new InequalMatricesException("tuples should have same length"));


			float result = 0;
			for (int i = 0; i < tuple1.Length; i++)
			{
				result += tuple1[i] * tuple2[i];
			}

			return result;
		}


		public static float[,] CrossProduct(float[,] matrix1, float[,] matrix2)
		{
			if (matrix1.GetLength(1) != matrix2.GetLength(0))
				throw (new InequalMatricesException("matrix1's length should be equal to matrix2's height"));

			float[,] resultMatrix = new float[matrix1.GetLength(0), matrix2.GetLength(1)];
			for (int i = 0; i < resultMatrix.GetLength(0); i++)
			{
				for (int j = 0; j < resultMatrix.GetLength(1); j++)
				{
					// float newElement = DotProduct(getRow(i, matrix1), getColumn(j, matrix2));
					// resultMatrix.SetValue(newElement, i, j);
					resultMatrix[i, j] = DotProduct(getRow(i, matrix1), getColumn(j, matrix2));
				}
			}

			return resultMatrix;
		}

	}


	public class InequalMatricesException : Exception
		{
			public InequalMatricesException(string message) : base(message)
			{
			}
		}

}