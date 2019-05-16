using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            Stack<char> parentheses = new Stack<char>();
            char[] openParenthese = new[] { '{', '[', '(' };

            string input = Console.ReadLine();
            bool isValid = true;

            foreach (var ch in input)
            {
                if (openParenthese.Contains(ch))
                {
                    parentheses.Push(ch);
                    continue;
                }

                if (parentheses.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (ch == ')')
                {
                    if (parentheses.Peek() == '(')
                    {
                        parentheses.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
                else if (ch == ']')
                {
                    if (parentheses.Peek() == '[')
                    {
                        parentheses.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
                else if (ch == '}')
                {
                    if (parentheses.Peek() == '{')
                    {
                        parentheses.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (parentheses.Count == 0 && isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }


        }
    }
}
