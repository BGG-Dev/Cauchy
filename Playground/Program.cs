namespace CauchyDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = 0;
            double h = 0.1;
            for (int i = 0; i < 11; i++)
            {
                Console.Write(x);
                Console.Write(" ");
                Console.Write(f(x));
                Console.WriteLine();
                x += h; 
            }
        }

        static double f(double x)
        {
            return 3.0 * Math.Pow(Math.E, x) - x * x - 2.0 * x - 2.0;
        }
    }
}