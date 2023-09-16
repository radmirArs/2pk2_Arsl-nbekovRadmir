namespace PZ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
            //создаем переменные для считывания данных, введеных пользователем
            Console.WriteLine("ВВедите сумму покупки");
            double purchaseAmount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите название дня недели на русском языке");
            string dayOfTheWeek = Console.ReadLine();
            dayOfTheWeek = dayOfTheWeek.ToLower();
            double discount = 0;
            //узнаем какой день недели ввел пользователь
            switch (dayOfTheWeek)
            {
                case "понедельник":
                    purchaseAmount = purchaseAmount - (purchaseAmount * 0.05);
                    discount = 5;
                    break;
                case "вторник":
                    purchaseAmount = purchaseAmount - (purchaseAmount * 0.05);
                    discount = 5;
                    break;
                case "среда":
                    purchaseAmount = purchaseAmount - (purchaseAmount * 0.05);
                    discount = 5;
                    break;
                case "четверг":
                    purchaseAmount = purchaseAmount - (purchaseAmount * 0.05);
                    discount = 5;
                    break;
                case "пятница":
                    purchaseAmount = purchaseAmount - (purchaseAmount * 0.05);
                    discount = 5;
                    break;
                case "суббота":
                    purchaseAmount = purchaseAmount - (purchaseAmount * 0.1);
                    discount = 10;
                    break;
                case "воскресенье":
                    purchaseAmount = purchaseAmount-(purchaseAmount * 0.1) ;
                    discount = 10;
                    break;
                default:
                    Console.WriteLine("вы ввели некоретные данные");
                    break;

            }
            //вывод для пользователя
            Console.WriteLine($"Сегодня {dayOfTheWeek}, поэтому скидка составит {discount}%. \nСумма с учетом скидки будет составлять {purchaseAmount}");





        }
    }
}