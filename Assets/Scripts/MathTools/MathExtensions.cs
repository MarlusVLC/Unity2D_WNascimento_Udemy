namespace MathTools
{
    public static class MathExtensions
    {
        
        // public static float[,] operator +(float[,] a, float[,] b)
        //     => 
        //

        // public static float[,] operator +(this float[,] matrix0, float[,] matrix2)
        // {
        //     return matrix0.Sum(matrix2);
        // }

        public static float[,] Sum(this float[,] matrix1, float[,] matrix2)
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
    }
}