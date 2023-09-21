namespace PZ_04_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char start = 'a'; 
            int n = Convert.ToInt32(Console.ReadLine()); 
            for (int i = 0; i < n; i++)
            {
                Console.Write(start); 
                start++; 
            }
        }
    }
}