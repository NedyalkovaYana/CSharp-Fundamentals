namespace _03.Word_count
{
    using System;   
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;

    class WordCount
    {
        static void Main()
        {
            Console.Write("Words file - ");
            var wordsFile = Console.ReadLine();

            var keysCounter = InitializeKeysCounter(wordsFile);

            CountKeyOccurances(keysCounter);
            WriteOutput(keysCounter);
        }

        static void WriteOutput(Dictionary<string, int> keysCounter)
        {
            using (var writer = new StreamWriter("../../CountedWords.txt"))
            {
                foreach (var kvp in keysCounter.OrderByDescending(a => a.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }

        static Dictionary<string, int> InitializeKeysCounter(string filePath)
        {
            var keys = ReadFile(filePath)
                .Split(new char[] {' ', '\n', '\r', '\t'}, StringSplitOptions.RemoveEmptyEntries);

            var keysCounter = new Dictionary<string, int>();

            foreach (var key in keys)
            {
                keysCounter[key] = 0;
            }

            return keysCounter;
        }

        static string ReadFile(string filePath)
        {
            var sb = new StringBuilder();

            using (var reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    sb.Append($" {line} ");
                    line = reader.ReadLine();
                }
            }
            return sb.ToString();
        }

        static void CountKeyOccurances(Dictionary<string, int> keysCounter)
        {
            Console.Write("Text file - ");
            var textFile = Console.ReadLine();

            var text = ReadFile(textFile);

            foreach (var key in keysCounter.Keys.OrderBy(x => x))
            {
                var matches = Regex.Matches(text.ToLower(), $@"\b{key}\b");
                keysCounter[key] = matches.Count;
            }
        }
    }
}
