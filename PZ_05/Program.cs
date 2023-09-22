namespace PZ_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число N");
            int n = Convert.ToInt32(Console.ReadLine());
            int number = 1;
            do
            {
                int kv = number * number;
                if (kv <= n)
                {
                    Console.Write(kv + " ");
                }
                number++;
            } while (number * number <= n);
        }
    }
}