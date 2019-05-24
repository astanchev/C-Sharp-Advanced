using System;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            Stack<string> stackOfTextConditions = new Stack<string>();

            int numberOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOperations; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                switch (command)
                {
                    case "1":
                        string stringToAppend = input[1];
                        stackOfTextConditions.Push(text);
                        text += stringToAppend;
                        break;
                    case "2":
                        int symbToRemove = int.Parse(input[1]);
                        stackOfTextConditions.Push(text);
                        text = text.Substring(0, text.Length - symbToRemove);
                        break;
                    case "3":
                        int elementToShow = int.Parse(input[1]);
                        Console.WriteLine(text[elementToShow-1]);
                        break;
                    case "4":
                        text = stackOfTextConditions.Pop();
                        break;
                    default: break;
                }
            }
        }
    }
}
