namespace _04._Find_Evens_or_Odds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class FindEvensorOdds
    {
        static void Main(string[] args)
        {
            int[] borders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int lowerBorder = Math.Min(borders[0], borders[1]);
            int upperBorder = Math.Max(borders[0], borders[1]);

            string filter = Console.ReadLine();

            Predicate<int> predicate = n => filter == "odd" ?
                n % 2 != 0 :
                n % 2 == 0;
            
            List<int> result = new List<int>();
            for (int i = lowerBorder; i <= upperBorder; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
