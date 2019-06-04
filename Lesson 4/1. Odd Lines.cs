namespace _1._Odd_Lines
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"files/01. Odd Lines/";
            string fileName = @"Input.txt";
            string fileOutput = @"Output.txt";
            string filePath = Path.Combine(path, fileName);
            string outputPath = Path.Combine(path, fileOutput);

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                int counter = 0;

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    while (line != null)
                    {
                        if (counter % 2 == 1)
                        {
                            writer.WriteLine($"{line}");
                        }
                        counter++;
                        line = reader.ReadLine();
                    }
                }

            }
        }
    }
}
