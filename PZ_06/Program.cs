using static System.Net.Mime.MediaTypeNames;

namespace PZ_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 10 чисел через пробел(n n1 n2 n3..n10");
            string numbers = Console.ReadLine();
            string [] num = numbers.Split(" ");
            double[] numbersarray = new double[num.Length] ;
            double num1 = 0;
            for (int i = 0; i < num.Length; i++)
            {
                numbersarray[i] = Convert.ToDouble(num[i]);
                if (numbersarray[i] == 0 || i < 11) break;
                num1 = num1 + numbersarray[i];
            }
            if (num1 > 0) { Console.WriteLine(num1);}
            else { Console.WriteLine("ошибка"); }

           
        }
    }
}
