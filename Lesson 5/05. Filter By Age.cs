using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<KeyValuePair<string, int>> people = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < count; i++)
            {
                string[] inputData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people.Add(new KeyValuePair<string, int>(inputData[0], int.Parse(inputData[1])));
            }

            string filter = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string[] pattern = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            people
                .Where(p => filter == "younger"? p.Value < age : p.Value >= age)
                .ToList()
                .ForEach(p => Printer(p, pattern));
        }

        private static void Printer(KeyValuePair<string, int> person, string[] pattern)
        {
            if (pattern.Length == 2)
            {
                Console.WriteLine(pattern[0] == "name" ?
                    $"{person.Key} - {person.Value}" :
                    $"{person.Value} - {person.Key}");
            }
            else
            {
                Console.WriteLine(pattern[0] == "name" ?
                    $"{person.Key}" :
                    $"{person.Value}");
            }
        }
    }
}
