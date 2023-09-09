using System;
namespace PZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Пользователь вводит значения
            Console.WriteLine("Введите значение для a (число или Пи). Для обозначения дробной части используйте символ \",\":");
            string aInput = Console.ReadLine();
            Console.WriteLine("Введите значение для b (число или Пи). Для обозначения дробной части используйте символ \",\":");
            string bInput = Console.ReadLine();
            Console.WriteLine("Введите значение для c (число или Пи). Для обозначения дробной части используйте символ \",\":");
            string cInput = Console.ReadLine();
            //создание переменных для изменения их значений
            double a;
            double b;
            double c;
            //проверяем содержание переменной a
            if (aInput.ToLower() == "пи") { a = Math.PI; }
            else { a = double.Parse(aInput); }
            //проверяем содержание переменной b
            if (bInput.ToLower() == "пи") { b = Math.PI; }
            else { b = double.Parse(bInput); }
            //проверяем содержание переменной c
            if (cInput.ToLower() == "пи") { c = Math.PI; }
            else { c = double.Parse(cInput); }

            //первое действие выражения
            double res1 = (Math.Cos(a + 2.0 * c) / (0.5 * Math.Abs(c)));
            //второе действие выражения
            double res2 = (Math.Sqrt(a - c) * Math.Tan(b / (3.0 * a)));

            //третье действие выражения
            double res3_1 = (Math.Log2(a) - Math.Pow(4.0 * (a), 1.0 / 3.0));
            double res3 = Math.Abs(res3_1);
            //вывод ответа выражения с введеными данными
            double resultat = (res1 + res2 + res3);
            Console.WriteLine("результат: " + resultat);


        }
    }
}