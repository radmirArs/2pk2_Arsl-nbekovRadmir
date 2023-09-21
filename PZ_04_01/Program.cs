namespace PZ_04_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = Convert.ToInt32(Console.ReadLine());
            int end = Convert.ToInt32(Console.ReadLine());
            int step = Convert.ToInt32(Console.ReadLine());
            for(int i = start; i < end; i++)
            {
                
                if(i%step == 0) 
                {
                    continue; 
                }
                Console.WriteLine(i);
            }
        }
    }
}