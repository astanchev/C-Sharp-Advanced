using System;
using System.Collections.Generic;
using System.Linq;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToArray();
            Stack<int> stack = new Stack<int>(input);
            Console.WriteLine(stack);
            Queue<int> queue = new Queue<int>(input);
            Console.WriteLine(queue);
            Console.WriteLine();

            foreach (var el in stack)
            {
                Console.WriteLine(el + 100);
            }

            Console.WriteLine();

            foreach (var el in queue)
            {
                Console.WriteLine(el+1000);
            }

        }
    }
}
