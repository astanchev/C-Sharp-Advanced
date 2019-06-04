using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string path = @"files/03. Word Count/";
            string fileWords = @"words.txt";
            string fileText = @"text.txt";
            string fileOutput = @"Output.txt";
            string inputWords = Path.Combine(path, fileWords);
            string inputText = Path.Combine(path, fileText);
            string outputPath = Path.Combine(path, fileOutput);

            using (StreamReader reader = new StreamReader(inputWords))
            {
                string[] words = reader.ReadLine()?.ToLower().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (!wordsCount.ContainsKey(word))
                    {
                        wordsCount[word] = 0;
                    }
                }
            }

            using (StreamReader reader = new StreamReader(inputText))
            {
                string pattern = @"[A-Za-z]+";
                Regex rg = new Regex(pattern);

                string line = reader.ReadLine()?.ToLower();

                while (line != null)
                {
                    foreach (Match match in rg.Matches(line))
                    {
                        if (wordsCount.ContainsKey(match.Value))
                        {
                            wordsCount[match.Value]++;
                        }
                    }

                    line = reader.ReadLine()?.ToLower();
                }
            }

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (var word in wordsCount.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
