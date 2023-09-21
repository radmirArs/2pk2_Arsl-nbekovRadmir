namespace PZ_04_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("значение i");
            int i = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("значение j");
            int j = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("разница");
            int difference = Convert.ToInt32(Console.ReadLine()); 
            while (Math.Abs(i - j) >= difference)
            {
                Console.WriteLine($"i = {i}, j = {j}"); 
                i++; 
                j--; 
            }
        }
    }
}