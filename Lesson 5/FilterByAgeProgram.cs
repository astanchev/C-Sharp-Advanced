using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_2._Filter_By_Age
{
    class FilterByAgeProgram
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
            string pattern = Console.ReadLine();

            Func<int, bool> tester = CreateTester(filter, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(pattern);
            PrintFilteredStudent(people, tester, printer);
        }

        private static void PrintFilteredStudent(List<KeyValuePair<string, int>> people, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            people
                .Where(w => tester(w.Value))
                .ToList()
                .ForEach(printer);
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string pattern)
        {
            switch (pattern)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Key}");
                case "age":
                    return person => Console.WriteLine($"{person.Value}");
                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");

                default: return null;
            }
        }

        private static Func<int, bool> CreateTester(string filter, int age)
        {
            switch (filter)
            {
                case "younger": return x => x < age;
                case "older": return x => x >= age;
                default: return null;
            }
        }
    }
}
