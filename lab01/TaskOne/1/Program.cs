using System;
using static System.Math;
using static System.Console;

namespace lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, z;

            x = double.Parse(ReadLine()); y = double.Parse(ReadLine()); z = double.Parse(ReadLine());

            if (z == 0)
            {
                WriteLine("Wrong input");
                System.Environment.Exit(1);
            }

            double a = Cos(x + ((x * y) / z));

            if (Cos(a) == 0)
            {
                WriteLine("Zero division!");
                System.Environment.Exit(1);
            }

            double b = Cos((x * x * x) / Cos(a));

            WriteLine(a.ToString() + " " + b.ToString());
        }
    }
}
