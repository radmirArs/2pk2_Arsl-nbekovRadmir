using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_11
{
    internal class Program
    {
        static void Main()
        {
            double a = Convert.ToDouble(Console.ReadLine()); // первый катет
            double b = Convert.ToDouble(Console.ReadLine()); ; // второй катет
            double c = GetHypotenuse(a, b); // вгипотенуза
            double area = GetArea(a, b); // площадь площадь
            double inradius = GetInradius(a, b); // радиус вписанной окружности

            Console.WriteLine("Гипотенуза: " + c);
            Console.WriteLine("Площадь: " + area);
            Console.WriteLine("Радиус вписанной окружности: " + inradius);
        }

        static double GetHypotenuse(double a, double b)
        {
            return Math.Sqrt(a*a + b*b);
        }

        static double GetArea(double a, double b)
        {
            return (a * b) / 2;
        }

        static double GetInradius(double a, double b)
        {
            double c = GetHypotenuse(a, b);
            return (a + b - c) / 2;
        }
    }
}
