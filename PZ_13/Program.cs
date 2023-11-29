using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine($"1 ЗАДАНИЕ \nВведите значение n:");
            double n = Convert.ToDouble(Console.ReadLine());
            double a1 = -5;
            double d = -0.5;
            double An = GetArithmeticProgression(a1, d, n);
            Console.WriteLine($"значение {n} - го члена: {An} ") ;
            Console.WriteLine();
            Console.WriteLine();
            

            //задание 2
            Console.WriteLine($"2 ЗАДАНИЕ \nВведите значение n:");
            double m = Convert.ToDouble(Console.ReadLine());
            double b1 = 1;
            double q = 0.4;
            double Bn = GetGeometricProgression(b1, q, m);
            Console.WriteLine($"значение {m} - го члена: {Bn} ");
            Console.WriteLine();
            Console.WriteLine();


            //задание 3
            Console.WriteLine("3 ЗАДАНИЕ");
            Console.WriteLine("Введите значение для числа А");
            int A = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение для числа B");
            int B = Convert.ToInt32(Console.ReadLine());
            if (A < B)
            {
                Console.WriteLine("Число А меньше числа В, поэтому интервал в порядке возрастания.");
                WriteIntervalBForA(A, B);
            }
            if (A > B)
            {
                Console.WriteLine("Число А больше числа В, поэтому интервал в порядке убывания.");
                WriteIntervalAForB(A, B);
            }
            Console.WriteLine();
            Console.WriteLine();


            //задание 4
            Console.WriteLine("4 ЗАДАНИЕ пункт 1");
            Console.WriteLine("Введите число:");
            int v = Convert.ToInt32(Console.ReadLine());
            int summ = Summ(v);
            Console.WriteLine($"Сумма чисел от одного до: {v}: \n{summ}");
        }


        // Метод для задания 1
        static double GetArithmeticProgression(double a1, double d, double n)
        {
            double An = 0;
            if (n != 0)
            {
                An = a1 + d * (n - 1);

                GetArithmeticProgression(a1, d, n-1);
            }
            return An;
        } 


        //метод для задания 2
        static double GetGeometricProgression(double b1, double q, double h)
        {
            double Bn = 0;
            if (h != 0)
            {
                Bn = b1 * Math.Pow(q, h - 1);
                GetGeometricProgression(b1, q, h - 1);
            }
            return Bn; 
        }


        //методы для задания 3:

        //для случая когда А<B
        static void WriteIntervalBForA(int a, int b)
        {
            
            if (a <= b)
            {
                Console.Write(a + " ");
                WriteIntervalBForA(a + 1, b);
            }
        }

        //для случая когда А>B
        static void WriteIntervalAForB(int a, int b)
        {
            
            if (b!=a)
            {
                Console.Write(a + " ");
                WriteIntervalAForB(a-1, b);
            }    
        }


        //методы для задания 4
        static int Summ(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n + Summ(n - 1);
            }
        }
    }
}
