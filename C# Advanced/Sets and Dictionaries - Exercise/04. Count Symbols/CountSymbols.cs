namespace _04.Count_Symbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class CountSymbols
    {
        static void Main()
        {
            var occurenceChars = new SortedDictionary<char, int>();

            var text = Console.ReadLine()
                .ToCharArray();

            for (int i = 0; i < text.Length; i++)
            {
                if (!occurenceChars.ContainsKey(text[i]))
                {
                    occurenceChars.Add(text[i], 0);
                }
                occurenceChars[text[i]] += 1;
            }

            foreach (var @chars in occurenceChars)
            {
                Console.WriteLine($"{@chars.Key}: {@chars.Value} time/s");
            }
        }
    }
}
