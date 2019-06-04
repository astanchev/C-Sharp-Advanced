using System.Collections.Generic;

namespace _4._Merge_Files
{
    using System;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"files/04. Merge Files/";
            string fileInput1 = @"FileOne.txt";
            string fileInput2 = @"FileTwo.txt";
            string inputPath1 = Path.Combine(path, fileInput1);
            string inputPath2 = Path.Combine(path, fileInput2);
            string fileOutput = @"Output.txt";
            string outputPath = Path.Combine(path, fileOutput);

            List<string> firstFile = new List<string>();
            List<string> secondFile = new List<string>();

            using (StreamReader reader = new StreamReader(inputPath1))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    firstFile.Add(line);

                    line = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader(inputPath2))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    secondFile.Add(line);

                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                int minLenght = Math.Min(firstFile.Count, secondFile.Count);

                for (int i = 0; i < minLenght; i++)
                {
                    writer.WriteLine(firstFile[i]);
                    writer.WriteLine(secondFile[i]);
                }

                if (firstFile.Count > secondFile.Count)
                {
                    for (int i = minLenght; i < firstFile.Count; i++)
                    {
                        writer.WriteLine(firstFile[i]);
                    }
                }
                else if (firstFile.Count < secondFile.Count)
                {
                    for (int i = minLenght; i < secondFile.Count; i++)
                    {
                        writer.WriteLine(secondFile[i]);
                    }
                }
            }
        }
    }
}
