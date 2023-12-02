using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;


namespace pz_14
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            //Дан файл с произвольным текстом.Пользователь в консоли вводит строку S, на консоль
            //выводятся из файла строки, содержащие в себе S как подстроку.


            Console.WriteLine("Введите подстроку S:");
            string S = Console.ReadLine();

            string fileLocation = @"C:\Users\Radmir\source\repos\2pk2_ArslanbekovRadmir\PZ_14\Files for PZ_14\text.txt";// Путь к текстовому документу
            
            if (File.Exists(fileLocation))
            {
                string[] lines = File.ReadAllLines(fileLocation);
                int count = 0;
                Console.WriteLine($"Строки содержащие подстроку \"{S}\":");
                foreach (string line in lines)
                {
                    if (line.Contains(S))
                    {
                        Console.WriteLine(line);
                        count++;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("Не найдены");
                }
            }
            else
            {
                Console.WriteLine($"Файл {fileLocation} не найден.");
            }
            
        }
    }
}
//else
//{
//    Console.WriteLine("Подстрока \"S\" не найдена в строке");
//}