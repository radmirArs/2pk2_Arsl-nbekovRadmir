namespace PZ_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 ЗАДАНИЕ");
            Console.WriteLine("Введите диапазон от");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите диапазон до");
            int end = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите шаг");
            int step = Convert.ToInt32(Console.ReadLine());
            for (int i0 = start; i0 < end; i0++)
            {
                if (i0 % step == 1)
                {
                    continue;
                }
                Console.WriteLine(i0);
            }


            Console.WriteLine("2 ЗАДАНИЕ");
            Console.WriteLine("введите начальный символ");
            char start1 = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("сколько символов вывести?");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i3 = 0; i3 < n; i3++)
            {
                Console.Write(start1);
                start1++;
            }
            Console.WriteLine(" ");


            Console.WriteLine("3 ЗАДАНИЕ");
            Console.WriteLine("введите n");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите m");
            int m1 = Convert.ToInt32(Console.ReadLine());

            for (int i2 = 0; i2 < m1; i2++)
            {
                for (int j2 = 0; j2 < n1; j2++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
            Console.WriteLine(" ");


            Console.WriteLine("4 ЗАДАНИЕ");
            Console.WriteLine("Введите диапазон от");
            int start2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите диапазон до");
            int end2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Кратно какому числу");
            int multiplicity = Convert.ToInt32(Console.ReadLine());
            for (int i1 = start2; i1 <= end2; i1++)
            {
                if (i1 % multiplicity == 0)
                {
                    Console.WriteLine(i1);
                }
            }


            Console.WriteLine("5 ЗАДАНИЕ");
            Console.WriteLine("Введите значение i");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение j");
            int j = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите разницу");
            int difference = Convert.ToInt32(Console.ReadLine());
            for (; Math.Abs(i - j) >= difference;)
            {
                Console.WriteLine($"i = {i}, j = {j}");
                i++;
                j--;
            }
        }
    }
}
