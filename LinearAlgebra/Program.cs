using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckReverseMatrix();
            Console.ReadLine();
        }

        public static void MatrixAddition()
        {
            int[,] matrix1 =
                {{1,2,3}, {3,2,1}, {3,2,1}};
            int[,] matrix2 =
                {{1,2,3}, {3,2,1}, {3,2,1}};

            //проверка
            if ((matrix1.GetLength(0) != matrix2.GetLength(0) && matrix1.GetLength(1) != matrix2.GetLength(1)))
                return;

            int[,] resultMatrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        public static float[,] MultiplyNumOnMatrix(float num, float[,] matrix)
        {
            //int num = 5;
            //int[,] matrix = { { 1, 2, 3 }, { 1, 2, 3 } };
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i, j] * num;
                }
            }
            return matrix;
        }
        public static float[,] MultiplyTwoMatrix(float[,] matrix1, float[,] matrix2)
        {
            //int[,] matrix1 =
            //    {{2,-3,1},
            //     {5,4,-2}};
            //int[,] matrix2 =
            //    {{-7,5},
            //     {2,-1},
            //     {4,3}};
            
            //проверка
            if (matrix1.GetLength(0) != matrix2.GetLength(1))
            {
                Console.WriteLine("Размерности матриц не соответствуют необходимым");
                return null;
            }
            float[,] resultMatrix = new float[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    float res = 0;
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        res += matrix1[i, k] * matrix2[k, j];
                    }
                    resultMatrix[i, j] = res;
                }
            }
            return resultMatrix;
        }
        public static float[,] Transp(float[,] matrix)
        {
            //int[,] matrix =
            //     {{2,-3,1},
            //     {5,4,-2}};
            float[,] resMatrix = new float[matrix.GetLength(1), matrix.GetLength(0)];

            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    resMatrix[c, r] = matrix[r, c];
                }
            }
            return resMatrix;
        }
        public static float? DetMatrix(float[,] matrix)
        {
            //int[,] matrix =
            //     {{1,-2,3},
            //     {4,0,6},
            //     {-7,8,9}};
            //int[,] matrix =
            //     {{11,-3},
            //     {-15,-2}};
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                Console.WriteLine("Матрица не квадратная!");
                return null;
            }

            float det = 0;
            switch (matrix.GetLength(0))
            {
                case 2:
                    det += (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]);
                    break;
                case 3:
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        det += (matrix[0, i] * (matrix[1, (i + 1) % 3] * matrix[2, (i + 2) % 3] - matrix[1, (i + 2) % 3] * matrix[2, (i + 1) % 3]));
                    }
                    break;
            }
            return det;
        }
        public static float[,] MinorMatrix(float[,] matrix)
        {
            float[,] minor = new float[matrix.GetLength(0), matrix.GetLength(1)];
            switch (matrix.GetLength(0))
            {
                case 2:
                    minor[0, 0] = matrix[1, 1];
                    minor[0, 1] = matrix[1, 0];
                    minor[1, 0] = matrix[0, 1];
                    minor[1, 1] = matrix[0, 0];
                    break;
                case 3:
                    minor[0, 0] = (float)DetMatrix(new float[,] { { matrix[1, 1], matrix[1, 2] }, { matrix[2, 1], matrix[2, 2] } });
                    minor[0, 1] = (float)DetMatrix(new float[,] { { matrix[1, 0], matrix[1, 2] }, { matrix[2, 0], matrix[2, 2] } });
                    minor[0, 2] = (float)DetMatrix(new float[,] { { matrix[1, 0], matrix[1, 1] }, { matrix[2, 0], matrix[2, 1] } });

                    minor[1, 0] = (float)DetMatrix(new float[,] { { matrix[0, 1], matrix[0, 2] }, { matrix[2, 1], matrix[2, 2] } });
                    minor[1, 1] = (float)DetMatrix(new float[,] { { matrix[0, 0], matrix[0, 2] }, { matrix[2, 0], matrix[2, 2] } });
                    minor[1, 2] = (float)DetMatrix(new float[,] { { matrix[0, 0], matrix[0, 1] }, { matrix[2, 0], matrix[2, 1] } });

                    minor[2, 0] = (float)DetMatrix(new float[,] { { matrix[0, 1], matrix[0, 2] }, { matrix[1, 1], matrix[1, 2] } });
                    minor[2, 1] = (float)DetMatrix(new float[,] { { matrix[0, 0], matrix[0, 2] }, { matrix[1, 0], matrix[1, 2] } });
                    minor[2, 2] = (float)DetMatrix(new float[,] { { matrix[0, 0], matrix[0, 1] }, { matrix[1, 0], matrix[1, 1] } });
                    break;
            }
            return minor;
        }
        public static float[,] AlgebrAddition(float[,] minor)
        {
            float[,] addition = minor;
            switch (addition.GetLength(0))
            {
                case 2:
                    addition[0, 1] = minor[0, 1] * -1;
                    addition[1, 0] = minor[1, 0] * -1;
                    break;
                case 3:
                    addition[0, 1] = minor[0, 1] * -1;
                    addition[1, 0] = minor[1, 0] * -1;
                    addition[1, 2] = minor[1, 2] * -1;
                    addition[2, 1] = minor[2, 1] * -1;
                    break;
            }
            return addition;
        }
        public static float[,] ReverseMatrix()
        {
            float[,] matrix =
                {{2,5,7},
                 {6,3,4},
                 {5,-2,-3}};
            //float[,] matrix =
            //     {{1,2},
            //     {3,4}};
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                Console.WriteLine("Матрица не квадратная!");
            }
            float det = (float)DetMatrix(matrix);
            if (det == 0)
            {
                Console.WriteLine("Определитель равен нулю!");
                return null;
            }
            float[,] reverseMatrix = MultiplyNumOnMatrix((1 / det), Transp(AlgebrAddition(MinorMatrix(matrix))));
            return reverseMatrix;
        }
        public static void CheckReverseMatrix()
        {
            //float[,] matrix =
            //    {{1,2},
            //     {3,4}};
            float[,] matrix =
                {{2,5,7},
                 {6,3,4},
                 {5,-2,-3}};
            ShowMatrix(MultiplyTwoMatrix(ReverseMatrix(), matrix));
        }
        public static void ShowMatrix(float[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
