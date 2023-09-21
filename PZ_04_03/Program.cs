namespace PZ_04_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите n");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите m");
            int m = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("#"); 
                }
                Console.WriteLine(); 
            }
        }
    }
}