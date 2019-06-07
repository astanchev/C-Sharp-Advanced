namespace _07._Predicate_For_Names
{
    using System;
    using System.Linq;
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int filterLenght = int.Parse(Console.ReadLine());
            
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(n => n.Length <= filterLenght)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
