using System;
using System.Collections;
using UnityEngine;

namespace MathTools
{
    public class MatrixMani
    {
					

		float[] tuple1 = new float[2] { 1, 2 };
		float[] tuple2 = new float[2] { 1, 6 };


		float DotProduct(float[] tuple1, float[] tuple2)
		{
			float result = 0;
			for (int i = 0; i < tuple1.GetLength(0); i++)
			{
				result += (float)tuple1.GetValue(i) * (float)tuple2.GetValue(i);
			}
			return result;
		}

		float[,] matrix0 = new float[2, 2] { { 0, 1 }, { 2, 3 } };
		float[,] matrix1 = new float[2, 2] { { 0, 1 }, { 2, 3 } };

		float[] getRow(int i, float[,] matrix)
		{
			float[] row = new float[matrix.GetLength(1)];
			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				row.SetValue(matrix.GetValue(i, j), j);
			}
			return row;
		}

		float[] getColumn(int j, float[,] matrix)
		{
			float[] column = new float[matrix.GetLength(0)];
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				column.SetValue(matrix.GetValue(i, j), i);
			}
			return column;
		}

		float[,] CrossProduct(float[,] matrix1, float[,] matrix2)
		{
			float[,] resultMatrix = new float[matrix1.GetLength(0), matrix2.GetLength(1)];
			for (int i = 0; i < resultMatrix.GetLength(0); i++)
			{
				for (int j = 0; j < resultMatrix.GetLength(1); j++)
				{
					float newElement = DotProduct(getRow(i, matrix1), getColumn(j, matrix2));
					resultMatrix.SetValue(newElement, i, j);
				}
			}
			return resultMatrix;
		}

		void printMatrix(float[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					Console.Write(" " + matrix.GetValue(i, j));
				}
				Console.WriteLine();
			}
		}
	}
}