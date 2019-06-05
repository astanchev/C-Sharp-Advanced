using System;
using System.Linq;

namespace _03._2_Count_Uppercase_Words
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]))
                .Select(w =>
                {
                    Console.WriteLine(w);
                    return w;
                })
                .ToList();
        }
    }
}
