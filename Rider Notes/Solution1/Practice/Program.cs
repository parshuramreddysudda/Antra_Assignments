namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int,int> math = (a, b) => a + b;

            Console.WriteLine($"{math.Invoke(34, 67)}");

            Predicate<int> isEven = (i => i % 2 == 0);
            Console.WriteLine($"{isEven(23857982)}");
        }
    }
}