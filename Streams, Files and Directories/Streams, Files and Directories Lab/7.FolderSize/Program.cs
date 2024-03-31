namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            long size = ReadFolder(folderPath);

            using (StreamWriter myWriter = new StreamWriter(outputFilePath))
            {
                myWriter.Write(ReadFolder(folderPath));
            }

            Console.WriteLine($"{size/1024.0}kb");

        }
        private static long ReadFolder(string folderPath)
        {
            long folderSize = 0;
            string[] files = Directory.GetFiles(folderPath);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                folderSize += fileInfo.Length;
            }

            string[] directories = Directory.GetDirectories(folderPath);

            foreach (var directory in directories)
            {
                folderSize += ReadFolder(folderPath);
            }

            return folderSize;
        }
    }
}
