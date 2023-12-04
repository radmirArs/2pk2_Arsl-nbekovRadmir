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

            string fileLocation = @"C:\Program Files";// Путь к текстовому документу
            Console.WriteLine($"Файлы, которые находятся на диске С по пути: \"C:\\Program Files\" ");
            string[] files = Directory.GetDirectories(fileLocation);//массив имен файлов
            if (files.Length == 0)
            {
                Console.WriteLine("ошибка");
            }
            else
            {
                Array.Sort(files, (a, b) => b.Length.CompareTo(a.Length));

                foreach (var item in files)
                {
                    Console.WriteLine(item);
                }
            }





        }
    }
}
