using System.Security.Cryptography;

namespace DirectoryTraversal
{
    using System;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            Dictionary<string, List<FileInfo>> reportContent = TraverseDirectory(path);
            
            WriteReportToDesktop(reportContent, reportFileName); 
        }

        public static Dictionary<string, List<FileInfo>> TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<FileInfo>> fileDictionary = new Dictionary<string, List<FileInfo>>();
            
            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);

                string currentFileExtension = info.Extension;

                if (!fileDictionary.ContainsKey(currentFileExtension))
                {
                    fileDictionary.Add(currentFileExtension, new List<FileInfo>());
                }

                fileDictionary[currentFileExtension].Add(info);
            }


            return fileDictionary; 
        }

        public static void WriteReportToDesktop(Dictionary<string, List<FileInfo>> reportContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            using (StreamWriter myWriter = 
                   new StreamWriter(path))
            {
                foreach (var file in reportContent
                             .OrderByDescending(x => x.Value.Count)
                             .ThenBy(x => x.Key))
                {
                    myWriter.WriteLine(file.Key);

                    foreach (var fileInfo in file.Value.OrderBy(x => x.Length).ThenBy(x => x.Name))
                    {
                        myWriter.WriteLine($"--{fileInfo.Name}{fileInfo.Extension} - {Math.Ceiling((double)fileInfo.Length)}kb");
                    }
                    
                }
            }
        }
    }
}