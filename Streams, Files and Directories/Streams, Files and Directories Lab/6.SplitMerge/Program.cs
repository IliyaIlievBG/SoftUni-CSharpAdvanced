using System.Text;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (StreamReader myReader = new StreamReader(sourceFilePath))
            {
                List<byte> allBytes = Encoding.UTF8.GetBytes(sourceFilePath).ToList();

                for (int i = 0; i < allBytes.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        using (StreamWriter partOneWriter = new StreamWriter(partOneFilePath))
                        {
                            partOneWriter.Write(allBytes[i]);
                        }
                    }
                    else
                    {
                        using (StreamWriter partTwoWriter = new StreamWriter(partTwoFilePath))
                        {
                            partTwoWriter.Write(allBytes[i]);
                        }
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            List<byte> partOneBytes = Encoding.UTF8.GetBytes(partOneFilePath).ToList();
            List<byte> partTwoBytes = Encoding.UTF8.GetBytes(partTwoFilePath).ToList();

            using (StreamWriter myWriter = new StreamWriter(joinedFilePath))
            {
                for (int i = 0; i < partOneBytes.Count; i++)
                {
                    if (i >= partTwoBytes.Count)
                    {
                        myWriter.Write(partOneBytes[i]);
                        continue;
                    }
                    myWriter.Write(partOneBytes[i]);
                    myWriter.Write(partTwoBytes[i]);
                }
            }

        }
    }
}