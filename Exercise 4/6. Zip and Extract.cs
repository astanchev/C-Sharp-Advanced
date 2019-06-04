namespace _6._Zip_and_Extract
{
    using System;
    using System.IO;
    using System.IO.Compression;
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "copyMe.png";
            string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFileNAme = @"myZip.zip";
            string outputPath = Path.Combine(pathDesktop, outputFileNAme);
            
            using (ZipArchive archive = ZipFile.Open(outputPath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(filePath, Path.GetFileName(filePath));
            }
        }
    }
}
