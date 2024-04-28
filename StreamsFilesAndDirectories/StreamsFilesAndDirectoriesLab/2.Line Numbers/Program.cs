namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamReader myReader = new StreamReader(inputFilePath))
            {
                using (StreamWriter myWriter = new StreamWriter(outputFilePath))
                {
                    int lineNumber = 0;

                    while (!myReader.EndOfStream)
                    {
                        lineNumber++;
                        string currentLine = myReader.ReadLine();

                        myWriter.WriteLine($"{lineNumber}. {currentLine}");
                    }

                }
            }
        }
    }
}