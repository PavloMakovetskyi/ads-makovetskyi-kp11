using System;
using System.Collections.Generic;
using static System.Console;

namespace Lab03
{
    class Program
    {
        public static void Main()
        {
            int n = int.Parse(ReadLine()), m = int.Parse(ReadLine());

            List<int> mainDiagonal = new List<int>(); List<int> antiDiagonal = new List<int>();

            int[,] matrix = GenerateMatrix(n, m, out mainDiagonal, out antiDiagonal);

            CocktailSortWithoutCenter(mainDiagonal); CocktailSortWithoutCenter(antiDiagonal);
        }

        static int[,] GenerateMatrix(int n, int m, out List<int> main, out List<int> anti)
        {
            main = new List<int>(); anti = new List<int>();
            
            Random rnd = new Random();
    
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rnd.Next(-50, 50);
                    if (i == j)
                        main.Add(matrix[i, j]);
                    if (i + j == n - 1)
                        anti.Add(matrix[i, j]);

                }
            }

            return matrix;
        }

        static void CocktailSortWithoutCenter(List<int> nums)
        {
            bool swapped = true;
            int start = 0;
            int end = nums.Count;
            int mid = nums[nums.Count / 2];

            while (swapped == true)
            {

                swapped = false;

                for (int i = start; i < end - 1; ++i)
                { 
                    if (nums[i] != mid && nums.Count % 2 == 0)
                    {

                    }
                    else if (nums[i] > nums[i + 1])
                    {
                        int temp = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = temp;
                        swapped = true;
                    }
                }

                if (swapped == false)
                    break;

                swapped = false;

                
                end = end - 1;

                
                for (int i = end - 1; i >= start; i--)
                {
                    if (nums[i] != mid && nums.Count % 2 == 0)
                    {

                    }
                    else if (nums[i] > nums[i + 1])
                    {
                        int temp = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = temp;
                        swapped = true;
                    }
                }

                start = start + 1;
            }

            foreach (int i in nums)
                Write(i + " ");
        }
    }
}
