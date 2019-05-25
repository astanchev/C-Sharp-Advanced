using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> brackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (ch == '(')
                {
                    brackets.Push(i);
                }
                else if (ch == ')')
                {
                    int startIndex = brackets.Pop();
                    int range = i - startIndex + 1;
                    Console.WriteLine(input.Substring(startIndex, range));
                }
            }
        }
    }
}
