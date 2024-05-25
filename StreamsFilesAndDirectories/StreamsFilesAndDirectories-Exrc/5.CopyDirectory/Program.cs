﻿namespace CopyDirectory
{
    using System;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }

            Directory.CreateDirectory(outputPath);

            string[] filesInInputDirectory = Directory.GetFiles(inputPath);

            foreach (var file in filesInInputDirectory)
            {
                string fileName = Path.GetFileName(file);
                string destination = Path.Combine(outputPath, fileName);
                File.Copy(file, destination);
            }
        }
    }
}