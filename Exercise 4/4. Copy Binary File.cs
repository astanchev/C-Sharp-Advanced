namespace _4._Copy_Binary_File
{
    using System;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "copyMe.png";
            string outputPath = "copyMe_Copied.png";

            using (FileStream inputFile = new FileStream(inputPath, FileMode.Open))
            {
                using (FileStream outputFile = new FileStream(outputPath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int size = inputFile.Read(buffer, 0, buffer.Length);

                        if (size == 0)
                        {
                            break;
                        }

                        outputFile.Write(buffer, 0, size);

                    }
                }
            }
        }
    }
}
