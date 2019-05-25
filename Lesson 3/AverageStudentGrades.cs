namespace _02._Average_Student_Grades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AverageStudentGrades
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentGrades = 
                new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                double grade = double.Parse(input[1]);

                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades[name] = new List<double>();
                }
                studentGrades[name].Add(grade);
            }

            foreach (var kvp in studentGrades)
            {
                Console.WriteLine($"{kvp.Key} -> " +
                                  $"{string.Join(" ", kvp.Value.Select(g => g.ToString("f2")))} " +
                                  $"(avg: {kvp.Value.Average():f2})");
            }

        }
    }
}
