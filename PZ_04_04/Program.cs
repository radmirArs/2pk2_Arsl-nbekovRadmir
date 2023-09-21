namespace PZ_04_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите диапазон от");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите диапазон до");
            int end = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Кратно какому числу");
            int multiplicity = Convert.ToInt32(Console.ReadLine());
            for (int i = start; i < end; i++)
            {

                if (i % multiplicity == 0)
                {
                    Console.WriteLine(i);
                }
                
            }
        }
    }
}