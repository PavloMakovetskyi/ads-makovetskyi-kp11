using System;
using static System.Math;
using static System.Console;

namespace ADS_Lab01_CodeEnv
{
    class Program
    {
        static void Main(string[] args)
        {

            int j = 1;

            // n = 2 cycle
            for (int i = 10; i < 100; i++)
            {
                if (Pow(i % 10, 2) + Pow(i / 10, 2) == i)
                {
                    WriteLine($"Two digit Armstrong number [{j}] = {i}");
                    j += 1;
                }
            }

            j = 1;
            WriteLine();

            // n = 3 cycle
            for (int i = 100; i < 1000; i++)
            {
                if (Pow(i % 10, 3) + Pow((i / 10) % 10, 3) + Pow(i / 100, 3) == i)
                {
                    WriteLine($"Three digit Armstrong number [{j}] = {i}");
                    j += 1;
                }

            }



            j = 1;
            WriteLine();

            // n = 4 cycle
            for (int i = 1000; i < 10000; i++)
            {
                if (Pow(i % 10, 4) + Pow((i / 10) % 10, 4) + Pow((i / 100) % 10, 4) + Pow((i / 1000), 4) == i)
                {
                    WriteLine($"Four digit Armstrong number [{j}] = {i}");
                    j += 1;
                }

            }

        }

    }

}

