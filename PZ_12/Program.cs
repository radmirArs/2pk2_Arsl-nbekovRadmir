using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PZ_12
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Ввдетие число n(кол-во строк)");

            int n = Convert.ToInt32(Console.ReadLine());

            string[] str = GenerateStrings(n);

            Console.Write("строки состоящие из символов \'*\'");

            foreach (string g in str)
            {
                Console.WriteLine(g);
            }

        }
        static string[] GenerateStrings(int n)
        {
            string[] str = new string[n + 1];

            for (int i = 1; i < n + 1; i++)
            {
                str[i] = new string('*', i);
            }

            if (n >= 3)
            {
                for (int i = 1; i < n + 1; i++)
                {
                    string elem = "";
                    int length = 0;
                    char[] elemChar;

                    if (str[i].Length % 2 != 0 && str[i].Length != 1)
                    {
                        length = str[i].Length / 2;
                        elem = str[i];
                        elemChar = elem.ToCharArray();
                        elemChar[length] = '.';
                        str[i] = new string(elemChar);
                    }
                }
            }
            return str;
        }
    }
}
