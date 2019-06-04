namespace _1._Even_Lines
{
    using System;
    using System.IO;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"text.txt";
            string outputPath = @"output.txt";

            int counter = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    string currentLine = reader.ReadLine();

                    while (currentLine != null)
                    {
                        if (counter % 2 == 0)
                        {
                            string replacedLine = ReplaceSymbs(currentLine);
                            string reverseWords = ReverseWords(replacedLine);

                            writer.WriteLine(reverseWords);
                        }
                        currentLine = reader.ReadLine();
                        counter++;
                    }
                }
            }
        }

        private static string ReplaceSymbs(string currentLine)
        {
            return currentLine.Replace("-", "@")
                .Replace(",", "@")
                .Replace(".", "@")
                .Replace("!", "@")
                .Replace("?", "@");
        }

        private static string ReverseWords(string replacedLine)
        {
            return string.Join(" ", replacedLine.Split().Reverse());
        }
    }
}
