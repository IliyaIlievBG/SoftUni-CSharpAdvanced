using System.IO.Compression;

namespace ZipAndExtract
{
    using System;
    using System.IO;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string zipArchiveFilePath = @"..\..\..\archivedCopyMe.zip";
            string outputFilePath = @"..\..\..\extractedCopy.png";

            ZipFileToArchive(inputFilePath, zipArchiveFilePath);

            ExtractFileFromArchive(zipArchiveFilePath, outputFilePath);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using (var zipper = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create))
            {
                string fileName = Path.GetFileName(inputFilePath);
                zipper.CreateEntryFromFile(inputFilePath, fileName);
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string outputFilePath)
        {
            using (var zipper = ZipFile.OpenRead(zipArchiveFilePath))
            {
                zipper.Entries.First().ExtractToFile(outputFilePath);
            }
        }
    }
}