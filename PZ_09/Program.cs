using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Дана непустая строка S и целое число N> 0.Вывести строку, содержащую символы строки S,
            //между которыми вставлено по N символов «*» (звездочка)
            //Пример:
            //S: “HELLO”, N = 3
            //“H***E***L***L***O”

            //Вводим строку через консоль
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            Console.WriteLine();
            //Вводим число через консоль
            Console.Write("Введите число N: ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Строка, с вставленными \"*\":");
            //Цикл для перебора каждого элемента
            
            for(int i = 0; i < str.Length-1; i++)
            {
                //выводим элемент строки
                Console.Write(str[i]);
                //ищем есть ли пробелы в строке
                if (str[i] == ' ') 
                { 
                    continue; 
                }
                else
                {
                    //Добавляем "*" после символов
                    for (int j = 0; j < N; j++)
                    { Console.Write('*'); }
                }
            }
            //Последний элемент просто выводим в консоль, ничего не добавляя в конце
            Console.Write(str[str.Length-1]);
            Console.WriteLine();

        }
    }
}
