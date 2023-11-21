using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "В качестве примера рассмотрим общение с продавцом в магазине. Сначала вы здороваетесь и улыбаетесь друг другу – это перцептивная сторона, во время которой вы настраиваетесь на общение, обмениваясь эмоциями. Далее вы перечисляете товары, а продавец называет итоговую стоимость – это коммуникативная часть. После этого вы расплачиваетесь, а продавец отдаёт вам товары и помогает сложить их в пакет – это интерактивная сторона вашего взаимодействия.";

            List<int> list = new List<int>();
            int g = 0;
            //записываем индексы точек в предложении
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (Convert.ToChar(str[i]) == '.' && str[i + 1] == ' ')
                {
                    list.Add(i);
                    g++;
                }
            }
            List<string> sentSecond = new List<string>();
            List<string> sentOther = new List<string>();
            List<string> sentLast = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                //пока i меньше чем координаты первой точки(удаляется первое предложение)
                //пока i больше или равно координаты последней точки(удаляется последнее предложение
                if (i <= list[0] + 1)
                {
                    sentSecond.Add(Convert.ToString(str[i]));

                }
                else if (i - 2 >= list[list.Count - 1])
                {
                    sentLast.Add(Convert.ToString(str[i]));
                }
                else
                {
                    sentOther.Add(Convert.ToString(str[i]));
                }

            }
            foreach (string h in sentLast) { Console.Write(h); }
            Console.Write(" ");
            foreach (string r in sentOther) { Console.Write(r); }
            foreach (string s in sentSecond) { Console.Write(s); }
            Console.WriteLine();

        }
    }
}
