using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultyThreads
{
    class Program
    {
        public const int M = 5;
        public const int N = 7;

        static void Main(string[] args)
        {
            List<int[][]> matrixes = new List<int[][]>();

            for (int i = 0; i < N; i++)
            {
                matrixes.Add(MatrixHelper.Init(M));
            }

            int size = matrixes.Count;

            while(size != 1)
            {
                int realSize = size / 2 * 2 == size ? size / 2 : size / 2 + 1;
                int[][][] tempAns = new int[realSize][][];
                Parallel.For(0, size / 2, (int i) => tempAns[i] = MultyplyMatrixes(matrixes[2 * i], matrixes[2 * i + 1]));
                if (realSize != size / 2)
                {
                    tempAns[realSize - 1] = matrixes.Last();
                }
                matrixes = tempAns.ToList();
                size = matrixes.Count();
            }

            matrixes.Last().ShowMatrix();
            Console.WriteLine();
        }

        private static int[][] MultyplyMatrixes(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] ansMatrix = new int[M][];
            Parallel.For(0, M, (int i) =>
            {
                ansMatrix[i] = new int[M];
                for (int j = 0; j < M; j++)
                {
                    ansMatrix[i][j] = SolveMultiplyingMatrixesElement(leftMatrix, rightMatrix, i, j);
                }
            });
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
                    ansMatrix[i][j] = rnd.Next(0, 4);
                }
            }
            return ansMatrix;
        }
    }
}
