namespace PZ_04_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите диапазон от");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите диапазон до");
            int end = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите шаг");
            int step = Convert.ToInt32(Console.ReadLine());
            for(int i = start; i < end; i++)
            {
                
                if(i%step == 1) 
                {
                    continue; 
                }
                Console.WriteLine(i);
            }
        }
    }
}
