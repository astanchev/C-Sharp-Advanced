using System;
using System.IO;

namespace _5._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"files/05. Slice File/";
            string fileName = @"sliceMe.txt";
            string filePath = Path.Combine(path, fileName);


            using (FileStream inputFile = new FileStream(filePath, FileMode.Open))
            {
                long size = inputFile.Length;
                int partSize = (int)Math.Ceiling(size / 4.0M);
                byte[] buffer = new byte[partSize];

                for (int i = 1; i <= 4; i++)
                {
                    using (FileStream outputFile = new FileStream(Path.Combine(path, $"Part-{i}.txt"),FileMode.Create))
                    {
                        int readedBytes = inputFile.Read(buffer, 0, partSize);
                        outputFile.Write(buffer, 0, readedBytes);
                    }
                }
            }
        }
    }
}
