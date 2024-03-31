using System.Text;

namespace EvenLines
{
    using System;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder output = new StringBuilder();

            using (StreamReader myReader = new StreamReader(inputFilePath))
            {
                int lineNumbr = 0;
                char[] charsToReplace = { '-', ',', '.', '!', '?' };

                while (!myReader.EndOfStream)
                {
                    string currentLine = myReader.ReadLine();
                    string[] wordsInCurrentLine = currentLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (lineNumbr % 2 == 0)
                    {
                        for (int i = wordsInCurrentLine.Length - 1; i >= 0; i--)
                        {
                            string currentWord = new string(wordsInCurrentLine[i]
                                .Select(c => charsToReplace.Contains(c) ? '@' : c).ToArray());

                            output.Append($"{currentWord} ");
                        }
                    }

                    lineNumbr++;
                }

            }

            return output.ToString().TrimEnd();
        }
    }
}