namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                Dictionary<string, int> wordsFrequency = new Dictionary<string, int>();

                using (StreamReader wordReader = new StreamReader(wordsFilePath))
                {
                    int linesCountInWordFile = 0;
                    while (!wordReader.EndOfStream)
                    {
                        linesCountInWordFile++;
                        string[] wordsInCurrentLineFromWordsFile =
                            wordReader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        using (StreamReader textReader = new StreamReader(textFilePath))
                        {
                            int LinesCountInTextFile = 0;
                            while (!textReader.EndOfStream)
                            {
                                LinesCountInTextFile++;
                                string[] wordsInCurrentLineFromTextFile =
                                    textReader.ReadLine()
                                        .Split(new string[] { "\r", "\n", ",", " ", ":", ";", "-", ",", ".", "!", "?", "..." }, StringSplitOptions.RemoveEmptyEntries);

                                foreach (var word in wordsInCurrentLineFromWordsFile)
                                {
                                    string wordToCheck = word.ToLower();
                                    int matchCount = wordsInCurrentLineFromTextFile.Count(x => x.ToLower() == wordToCheck);
                                    if (matchCount > 0)
                                    {
                                        if (!wordsFrequency.ContainsKey(word))
                                        {
                                            wordsFrequency.Add(word, matchCount);
                                        }
                                        else
                                        {
                                            wordsFrequency[word]+=matchCount;
                                        }
                                    }
                                }

                            }

                            foreach (var word in wordsFrequency.OrderByDescending(x => x.Value))
                            {
                                writer.WriteLine($"{word.Key} - {word.Value}");
                            }
                        }
                    }
                }
            }
        }
    }
}