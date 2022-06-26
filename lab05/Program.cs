using System;

namespace CountingSort
{
    internal class Program
    {
        private static int[,] CountingSort(int[,] arr)
        {
            int countOfElements = 0;
            int max = arr[1, 0];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j % 2 != 0 && i % 2 == 0)
                    {
                        countOfElements++;
                        if(max < arr[i, j])
                        {
                            max = arr[i, j];
                        }
                    }
                }
            }
            int[] lineArray = new int[countOfElements];
            int[] counters = new int[max+1];
            
            for (int i = 0, k = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j % 2 != 0 && i % 2 == 0)
                    {
                        lineArray[k++] = arr[i, j];
                    }
                }
            }

            for (int i = 0; i < lineArray.Length; i++)
            {
                counters[lineArray[i]] = counters[lineArray[i]] + 1;
            }
            for (int j = 1; j < counters.Length; j++)
            {
                counters[j] = counters[j] + counters[j - 1];
            }
            int[] lineResult = new int[lineArray.Length];
            for (int i = lineArray.Length-1; i >=0; i--)
            {
                counters[lineArray[i]] = counters[lineArray[i]] - 1;
                lineResult[counters[lineArray[i]]] = lineArray[i];
            }

            int[,] result = new int[arr.GetLength(0), arr.GetLength(1)];
            for (int i = 0, k = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j % 2 != 0 && i % 2 == 0)
                    {
                        result[i, j] = lineResult[k++];
                    }
                    else
                    {
                        result[i, j] = arr[i, j];
                    }
                }
            }

            return result;
        }

        static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write("{ ");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j % 2 != 0 && i % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(arr[i, j] + ",\t");
                    Console.ResetColor();
                }
                Console.Write("}\n");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            int[,] arr = new int[4, 4]; 
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = rand.Next(1, 30);   
                }
            }

            int[,] newarr = CountingSort(arr);

            PrintArray(arr);
            PrintArray(newarr);

        }
    }
}
