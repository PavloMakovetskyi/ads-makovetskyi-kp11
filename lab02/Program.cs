using System;
using System.Collections.Generic;
using static System.Console;

namespace Lab02
{
    class Program
    {
        public static void Main()
        {
            int n = 3;
            int m = 3;

            GenerateMatrixAndMainCode(n, m);
        }

        static void GenerateMatrixAndMainCode(int n, int m)
        {
            List<int> upTriangle = new List<int>();
            List<int> bottomTriangle = new List<int>();

            List<int> MoreThanHalfSum = new List<int>(); List<Tuple<int, int>> MoreThanHalfSumIndexes = new List<Tuple<int, int>>();

            int halfSum = 0;

            Random rnd = new Random();

            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rnd.Next(-50, 50);
                    if (i < j)
                        upTriangle.Add(matrix[i, j]);
                    if (i > j)
                    {
                        bottomTriangle.Add(matrix[i, j]);
                    }
                    if (i == j)
                        halfSum += matrix[i, j];
                }
            }  

            int minUpTr = upTriangle[0];
            for (int i = 0; i < upTriangle.Count; i++)
                if (upTriangle[i] < minUpTr)
                    minUpTr = upTriangle[i];

            halfSum /= 2;
            for (int j = 0; j < bottomTriangle.Count; j++)
                if (bottomTriangle[j] > halfSum)
                {
                    MoreThanHalfSum.Add(bottomTriangle[j]);
                    MoreThanHalfSumIndexes.Add(IndexOfElement(matrix, bottomTriangle[j]));
                }
                    
            
            Tuple<int, int> IndexOfElement(int[,] matrix, int value)
            {
                int w = matrix.GetLength(0); int h = matrix.GetLength(1);

                for (int x = 0; x < w; ++x)
                {
                    for (int y = 0; y < h; ++y)
                    {
                        if (matrix[x, y].Equals(value))
                            return Tuple.Create(x, y);
                    }
                }

                return Tuple.Create(-1, -1);

            }

            WriteLine("First sequence: ");
            foreach (int num in upTriangle)
            {
                WriteLine(num);
            }

            WriteLine("Second sequence: ");
            foreach (int num in bottomTriangle)
            {
                WriteLine(num);
            }

            WriteLine($"Half-sum: {halfSum}");

            foreach (Tuple<int, int> tuple in MoreThanHalfSumIndexes)
                Write($"{tuple.Item1}, {tuple.Item2}");
        }
    }
}