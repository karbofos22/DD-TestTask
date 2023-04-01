using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StopWord;

namespace DD_TestTask
{
    internal class UniqueWords
    {
        private readonly string FilesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Files");

        private Dictionary<string, int> uniqueWords = new();

        public void ProcessFile(string inputFileName)
        {
            if (string.IsNullOrWhiteSpace(inputFileName))
            {
                throw new ArgumentException("Invalid input file path.", nameof(inputFileName));
            }

            try
            {
                string inputFile = Path.Combine(FilesDirectory, inputFileName + ".fb2");
                string text = File.ReadAllText(inputFile);

                text = Regex.Replace(text, "<.*?>", string.Empty);
                text = Regex.Replace(text, @"[^\p{L}\p{N}\s]", string.Empty);

                string[] words = text.Split(new[] { ' ', ',', '.', ';', ':', '-', '!', '?', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                var stopWords = StopWords.GetStopWords("ru");

                foreach (string word in words)
                {
                    string cleanedWord = word.ToLowerInvariant().Trim();

                    if (stopWords.Contains(cleanedWord))
                    {
                        continue;
                    }

                    if (uniqueWords.ContainsKey(cleanedWord))
                    {
                        uniqueWords[cleanedWord]++;
                    }
                    else
                    {
                        uniqueWords[cleanedWord] = 1;
                    }
                }

                var sortedWords = uniqueWords.OrderByDescending(pair => pair.Value);

                string outputPath = Path.Combine(FilesDirectory, $"{inputFileName}_unique_words.txt");

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    foreach (var pair in sortedWords)
                    {
                        writer.WriteLine($"{pair.Key,-18}\t{pair.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing the file: {ex.Message}");
            }
        }
    }
}
