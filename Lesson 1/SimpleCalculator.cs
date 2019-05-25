using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count>1)
            {
                int number1 = int.Parse(stack.Pop());
                string oper = stack.Pop();
                int number2 = int.Parse(stack.Pop());
                string newNumber = string.Empty;

                if (oper == "+")
                {
                    newNumber = (number1+number2).ToString();
                    stack.Push(newNumber);
                }
                else if (oper == "-")
                {
                    newNumber = (number1 - number2).ToString();
                    stack.Push(newNumber);
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
