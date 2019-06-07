namespace _02._Knights_of_Honor
{
    using System;
    using System.Linq;
    class KnightsofHonor
    {
        static void Main(string[] args)
        {
            Action<string> Print = msg => Console.WriteLine($"Sir {msg}");
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(Print);
        }
    }
}
