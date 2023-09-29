namespace PZ_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Дан массив nums[4, 5], заполненный случайными целыми числами. Найти максимальный
            элемент для каждого столбца и записать все эти максимальные элементы в одномерный
            массив.Вывести его значения*/
            int[,] nums = new int[4, 5];
            // Заполнение массива случайными числами
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    nums[i, j] = random.Next(10);
                }
            }
            // Нахождение максимальных элементов
            int[] maxEl = new int[5];
            for (int j = 0; j < 5; j++)
            {
                int max = nums[0, j];
                for (int i = 1; i < 4; i++)
                {
                    if (nums[i, j] > max)
                    {
                        max = nums[i, j];
                    }
                }
                maxEl[j] = max;
            }
            // Вывод значений массива
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(maxEl[i]);
            }
        }
    }
}