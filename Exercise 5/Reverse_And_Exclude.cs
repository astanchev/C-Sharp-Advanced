using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_2._Reverse_And_Exclude
{
    class Reverse_And_Exclude
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int divider = int.Parse(Console.ReadLine());

            Predicate<int> predicate = n => n % divider != 0;  
            Action<List<int>> Print = list => Console.WriteLine(string.Join(" ", list));
            Action<List<int>> ReverseList = l => l.Reverse();
            Func<List<int>, List<int>> RemoveElements = l => l.Where(n => predicate(n)).ToList();

            ReverseList(input);            
            Print(RemoveElements(input));
        }
    }
}
