namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamWriter myWriter = new StreamWriter(outputFilePath))
            {
                List<string> firsFileLines = new List<string>();
                List<string> secondFileLines = new List<string>();

                using (StreamReader readerOne = new StreamReader(firstInputFilePath))
                {
                    while (!readerOne.EndOfStream)
                    {
                        string nextLine = GetNextLine(readerOne);
                        firsFileLines.Add(nextLine);
                    }
                }

                using (StreamReader readerTwo = new StreamReader(secondInputFilePath))
                {
                    while (!readerTwo.EndOfStream)
                    {
                        string nextLine = GetNextLine(readerTwo);
                        secondFileLines.Add(nextLine);
                    }
                }

                int iterationsCount = Math.Max(firsFileLines.Count, secondFileLines.Count);

                for (int i = 0; i < iterationsCount; i++)
                {
                    if (i < firsFileLines.Count)
                    {
                        myWriter.WriteLine(firsFileLines[i]);
                    }

                    if (i < secondFileLines.Count)
                    {
                        myWriter.WriteLine(secondFileLines[i]);
                    }
                }
            }
            static string GetNextLine(StreamReader reader)
            {
                return reader.ReadLine();
            }
        }
    }
}