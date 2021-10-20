using System;
using static System.Math;
using static System.Console;

namespace ADS_Lab01_CodeEnv
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(ReadLine()); double y = double.Parse(ReadLine()); double z = double.Parse(ReadLine());
            double a, b, quadratic_root = 0;

            if ((x * x * x) + 5 * Pow(y, -z) + (z * z) <= 0)
            {
                WriteLine("Zero division");
                System.Environment.Exit(1);
            }
            else
            {
                quadratic_root = Sqrt((x * x * x) + 5 * Pow(y, -z) + (z * z));
            }

            a = (y - Sqrt(Abs(x * x * x))) / quadratic_root;

            b = Sin(Pow(a, -x) + y);

            WriteLine(a.ToString() + " " + b.ToString());
        }
    }
}
