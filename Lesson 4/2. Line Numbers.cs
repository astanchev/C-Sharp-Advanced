namespace _2._Line_Numbers
{
    using System;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"files/02. Line Numbers/";
            string fileInput = @"Input.txt";
            string fileOutput = @"Output.txt";
            string inputPath = Path.Combine(path, fileInput);
            string outputPath = Path.Combine(path, fileOutput);

            using (StreamReader reader = new StreamReader(inputPath))
            {
                int counter = 1;
                string line = reader.ReadLine();

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{counter++}. {line}");
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
