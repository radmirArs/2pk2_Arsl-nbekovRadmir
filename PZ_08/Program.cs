using System;

namespace PZ_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод массива с рандомными значениями");
            Random rnd = new Random();
            int[][] array = new int[10][];//создание ступенчатого массива
            int[] LastNum = new int[10];//массив для последних чисел каждой строки
            int[] maxElements = new int[10];//массив для максимальных элементов каждой строки
            int[] FirstNum = new int[10];//массив для первых чисел каждой строки
            int max = 0;//переменная для поиска максимального числа
            int[][] arrayForChange = new int[10][];
            //заполнение массива рандомными числами и вывод массива
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new int[rnd.Next(3, 11)];
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = rnd.Next(1, 101);

                    Console.Write(array[i][j] + " ");
                    //поиск максимальных чисел в каждой строке и запись их в массив
                    if (array[i][j] > max)
                    {
                        max = array[i][j];
                    }
                    //запись первого числа каждой строки в массив
                    if (j == 0)
                    {
                        FirstNum[i] = array[i][j];
                    }
                }
                maxElements[i] = max;
                max = 0;
                //поиск последнего числа 
                LastNum[i] = array[i][array[i].Length - 1];
                Console.WriteLine();
            }
            Console.WriteLine("Последние элементы каждого массива: ");
            foreach (int s in LastNum) { Console.Write(s + " "); }
            Console.WriteLine();
            Console.WriteLine("Максимальные значения каждого массива: ");
            foreach (int e in maxElements) { Console.Write(e + " "); }
            Console.WriteLine();
            //запись массива array в массив arrayForChange
            for (int i = 0; i < array.Length; i++)
            {
                arrayForChange[i] = new int[array[i].Length];
                for (int j = 0; j < array[i].Length; j++)
                {
                    arrayForChange[i][j] = array[i][j];
                }
            }
            //Замена первых элементов каждого массива максимальными числами
            Console.WriteLine("Замена первых элементов каждого массива максимальными числами");
            int forFirst = 0;
            int forMax = 0;
            for (int i = 0; i < arrayForChange.Length; i++)
            {
                for (int j = 0; j < arrayForChange[i].Length; j++)
                {
                    if (arrayForChange[i][j] == FirstNum[forFirst])
                    {
                        arrayForChange[i][j] = maxElements[forFirst];

                    }
                    else if (arrayForChange[i][j] == maxElements[forMax])
                    {
                        arrayForChange[i][j] = FirstNum[forMax];

                    }
                    Console.Write(arrayForChange[i][j] + " ");
                }
                forFirst++;
                forMax++;
                Console.WriteLine();
            }
            Console.WriteLine("Реверс массивы");
            for (int i = 0; i < array.Length; i++)
            {
                Array.Reverse(array[i]);
                Console.WriteLine(String.Join(' ', array[i]));
            }
            //среднее значение
            int averageValue = 0;
            Console.WriteLine("Нашли среднее значение в каждой строки");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    averageValue += array[i][j];
                }
                double countAverageValue = averageValue / array[i].Length;
                Console.Write(countAverageValue + " ");
                countAverageValue = 0;
                averageValue = 0;
            }

        }
    }
}