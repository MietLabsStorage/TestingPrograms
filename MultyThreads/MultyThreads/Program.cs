using System;

namespace MultyThreads
{
    class Program
    {
        public const int M = 5;

        static void Main(string[] args)
        {
            int[][] left = MatrixHelper.Init(M);
            int[][] right = MatrixHelper.Init(M);
            int[][] ans;


            ans = MultyplyMatrixes(left, right);

            left.ShowMatrix();
            Console.WriteLine();

            right.ShowMatrix();
            Console.WriteLine();

            ans.ShowMatrix();
            Console.WriteLine();
        }

        private static int[][] MultyplyMatrixes(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] ansMatrix = new int[M][];
            for(int i = 0; i < M; i++)
            {
                ansMatrix[i] = new int[M];
                for(int j = 0; j < M; j++)
                {
                    ansMatrix[i][j] = SolveMultiplyingMatrixesElement(leftMatrix, rightMatrix, i, j);
                }
            }
            return ansMatrix;
        }

        private static int SolveMultiplyingMatrixesElement(int[][] leftMatrix, int[][] rightMatrix, int raw, int column)
        {
            int ans = 0;
            for(int k = 0; k < M; k++)
            {
                ans += leftMatrix[raw][k] * rightMatrix[k][column];
            }
            return ans;
        }
    }

    public static class MatrixHelper
    {
        private static Random rnd = new Random((int)DateTime.Now.Ticks);

        public static void ShowMatrix(this int[][] matrix)
        {
            int M = matrix.Length;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        public static int[][] Init(int M)
        {
            int[][] ansMatrix = new int[M][];
            for (int i = 0; i < M; i++)
            {
                ansMatrix[i] = new int[M];
                for (int j = 0; j < M; j++)
                {
                    ansMatrix[i][j] = rnd.Next(0, 9);
                }
            }
            return ansMatrix;
        }
    }
}
