using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class StackSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                               .Split()
                               .Select(int.Parse)
                               .ToArray();
            Stack<int> stack = new Stack<int>(arr);

            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "end")
                {
                    break;
                }

                string[] line = input.Split();
                string command = line[0];

                if (command == "add")
                {
                    stack.Push(int.Parse(line[1]));
                    stack.Push(int.Parse(line[2]));
                }
                else if (command == "remove")
                {
                    int count = int.Parse(line[1]);
                    if (count < stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
