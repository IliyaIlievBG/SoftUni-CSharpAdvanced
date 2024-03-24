namespace ExtractSpecialBytes
{
    using System.Text;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (FileStream myWriter = new FileStream(outputPath, FileMode.Open))
            {
                HashSet<byte> bytes = new HashSet<byte>();

                using (StreamReader myReader = new StreamReader(bytesFilePath))
                {
                    bytes = Encoding.UTF8.GetBytes(bytesFilePath).ToHashSet();
                }

                using (FileStream myReader = new FileStream(binaryFilePath, FileMode.Open))
                {
                    byte[] bytesArray = new byte[1];

                    int currentByte;
                    while ((currentByte = myReader.Read(bytesArray, 0, bytesArray.Length)) != 0)
                    {
                        if (bytes.Contains(bytesArray[0]))
                        {
                            myWriter.Write(bytesArray, 0, bytesArray.Length);
                        }
                    }
                }
            }
        }
    }
}