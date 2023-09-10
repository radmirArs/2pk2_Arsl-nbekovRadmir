using System;
namespace PZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           //Пользователь вводит значения
            Console.WriteLine("Если вам требуется разделить или умножить число пи на число,\nто впишите это выражение в таком формате: \"число(если не требуется то напишите 1) * пи / любое число\".\nДля обозначения дробной части используйте символ \",\"");
            Console.WriteLine("Введите значение для a (число или пи):");
            string aInput = Console.ReadLine();
            Console.WriteLine("Введите значение для b (число или пи):");
            string bInput = Console.ReadLine();
            Console.WriteLine("Введите значение для c (число или пи):");
            string cInput = Console.ReadLine();
            //создание переменных для изменения их значений
            double a = 1;
            double b = 1;
            double c = 1;
            //проверяем содержание переменной a
            int aHavePi = aInput.IndexOf("пи /");
            bool aPI;
            if (aHavePi >= 0)
            {
                aPI = true;
                if (aPI)
                {
                    string[] aPi = aInput.Split(' ');
                    double a1 = double.Parse(aPi[0]) * Math.PI / double.Parse(aPi[4]);
                    a = a1;
                }
                Console.WriteLine(a);
            }
            else if (aInput.ToLower() == "пи") { a = Math.PI; }
            else { a = double.Parse(aInput); }
            //проверяем содержание переменной b
            int bHavePi = bInput.IndexOf("пи /");
            bool bPI;
            if (bHavePi >= 0)
            {
                bPI = true;
                if (bPI)
                {
                    string[] bPi = bInput.Split(' ');
                    b = double.Parse(bPi[0]) * Math.PI / double.Parse(bPi[4]);
                }
            }
            else if (bInput.ToLower() == "пи") { b = Math.PI; }
            else { b = double.Parse(bInput); }
            //проверяем содержание переменной c
            int cHavePi = cInput.IndexOf("пи /");
            bool cPI;
            if (cHavePi >= 0)
            {
                cPI = true;
                if (cPI)
                {
                    string[] cPi = cInput.Split(' ');
                    c = double.Parse(cPi[0]) * Math.PI / double.Parse(cPi[4]);
                }
            }
            else if (cInput.ToLower() == "пи") { c = Math.PI; }
            else { c = double.Parse(cInput); }

            //первое действие выражения
            double res1 = (Math.Cos(a + 2.0 * c) / (0.5 * Math.Abs(c)));
            //второе действие выражения
            double res2 = (Math.Sqrt(a - c) * Math.Tan(b / (3.0 * a)));

            //третье действие выражения
            double res3_1 = (Math.Log(a) - Math.Pow(4.0 * (a), 1.0 / 3.0));
            double res3 = Math.Abs(res3_1);
            //вывод ответа выражения с введеными данными
            double resultat = (res1 + res2 + res3);
            Console.WriteLine("результат: " + Math.Round(resultat));


        }
    }
}
