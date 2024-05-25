namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\newFile.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }
        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] inputFileLines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < inputFileLines.Length; i++)
            {
                int lettersCount = inputFileLines[i].Where(char.IsLetter).Count();
                int punctuationMarksCount = inputFileLines[i].Where(char.IsPunctuation).Count();

                inputFileLines[i] = $"Line {i + 1}: {inputFileLines[i]} ({lettersCount})({punctuationMarksCount})";
            }

            File.WriteAllLines(outputFilePath, inputFileLines);
        }
    }
}

