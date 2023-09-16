namespace PZ_03_доп
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // массив в котором хранится 3 тарифа
            //создать бесконечный цикл  пока не введется пустая строка
            // выводим на экран пользователю на экран эти три тарифа
            //у каждого тарифа есть своя цена 
            // условием выбираем какой тариф выбрал пользователь 
            // вводим имя и фамилию пользователя
            // прибавляем сумму тарифа
            // добавляем к счетчику пользователей 1 
            // выводим на экран общую сумму на всех зарегисрированных пользоваетеллей и их количество
            string[] tarif = new string[] {"1 тариф", "2 тариф", "3 тариф"};
            List<string> USerName = new List<string>();
            int Sum= 0;
            int counth = 0;
            
            int i = 0;
            while (i == 0)
            {
                Console.WriteLine("Выберите тариф из 3 представленных:(1 тариф, 2 тариф и 3 тариф)");
                string tarifForUser = Console.ReadLine();
                string Name;
                switch (tarifForUser)
                {
                    case "1 тариф":

                        Console.WriteLine("стрижка одной насадкой. Цена 400 рублей. Подходит для котортких волос, и не требует много времени(20-30 минут)");
                        Console.WriteLine("Введите Имя");
                        Name = Console.ReadLine();
                        USerName.Add(Name);
                        Sum += 400;
                        break;
                    case "2 тариф":
                        Console.WriteLine("стрижка ножницами и машинкой. Цена 1200 рублей. Подходит для волос средней длины и требует порядка полутора часа");
                        Name = Console.ReadLine();
                        USerName.Add(Name);
                        Sum += 1200;
                        break;
                    case "3 тариф":
                        Console.WriteLine("стрижка головы с ножницами и машинкой, и уход за бородой, усами. Цена  4000 рублей,. Требуется индивидуальный подход)");
                        Name = Console.ReadLine();
                        USerName.Add(Name);
                        Sum += 4800;
                        break;
                    default:
                        i++;
                        break;
                }
                counth++;
            }
            Console.WriteLine($"Сумма всех стрижек: {Sum}, количесвто всех стрижек{counth}");

        }
    }
}
