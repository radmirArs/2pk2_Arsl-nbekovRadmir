namespace PZ_04_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите начальный символ");
            char start = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("сколько символов вывести?");
            int n = Convert.ToInt32(Console.ReadLine()); 
            for (int i = 0; i < n; i++)
            {
                Console.Write(start); 
                start++; 
            }
        }
    }
}
