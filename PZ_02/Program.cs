namespace PZ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //пользователь вводит значения для перменных а и b
            Console.WriteLine("Введите значение для переменной a");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите значение для переменной b");
            double b = Convert.ToDouble(Console.ReadLine());
            //создали переменны х, у, z
            double x;
            double y;
            double z;
            //проверяем число на а
            if (a - 2.0 == 0) { Console.WriteLine("на ноль делить нельзя"); }
            else
            {
                //проверяем переменную а по отношению к 3
                if (a > 3.0)
                {
                    x = 2.0 * a;
                }


                else
                {

                    x = (6.0 * (b + 8.0)) / (a - 2.0);
                }
                //проверяем переменную х по отношению к 10
                if (x <= 10)
                {
                    y = Math.Sin(a * x);
                }
                else
                {
                    y = Math.Cos(b * x) / a;
                }
                //считаем z
                z = 2 * x * y - Math.Pow(y, 2);
                //выводим все числа, округляя некоторые из них
                Console.WriteLine($"{a}, {b}, {Math.Round(x, 2)}, {Math.Round(y, 2)}, {Math.Round(z, 2)}");
            }
        }
    }
}