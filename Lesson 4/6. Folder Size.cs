using System;
using System.IO;

namespace _6._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\files\06. Folder Size\TestFolder\";
            string[] files = Directory.GetFiles(path);
            double sum = 0;
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }
            sum = sum / 1024 / 1024;
            File.WriteAllText("оutput.txt", sum.ToString());

        }
    }
}
