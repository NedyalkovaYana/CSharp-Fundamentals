using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Treasure_Map
{
    class Program
    {
        private static List<string> instructions;

        static void Main(string[] args)
         {
            instructions = ReadAllInstructions();
            ParseInstructions();
        }

        private static List<string> ReadAllInstructions()
        {
            List<string> instructions = new List<string>();

            int numberOfInstructions = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInstructions; i++)
            {
                instructions.Add(Console.ReadLine());
            }

            return instructions;
        }

        private static void ParseInstructions()
        {
            string validInstructionPattern =
                @"\#.*?\b(?<streetName>[a-zA-Z]{4})\b.*?[^\d](\d{3}-(\d{6}|\d{4}))(\!|[^\d].*?\!)|\!.*?\b(?<streetName>[a-zA-Z]{4})\b.*?[^\d](\d{3}-(\d{6}|\d{4}))(\#|[^\d].*?\#)";

            for (int i = 0; i < instructions.Count; i++)
            {
                // get all valid instructions
                MatchCollection matches = Regex.Matches(instructions[i], validInstructionPattern);

                if (matches.Count == 0)
                {
                    continue;
                }

                int indexOfInstruction = matches.Count / 2;

                // match street number - password pair
                MatchCollection pairMatches = Regex.Matches(matches[indexOfInstruction].Value,
                    @"[^\d](?<streetNumber>\d{3})-(?<password>\d{6}|\d{4})[^\d]");

                string streetName = matches[indexOfInstruction].Groups["streetName"].Value;
                string streetNumber = pairMatches[pairMatches.Count - 1].Groups["streetNumber"].Value;
                string password = pairMatches[pairMatches.Count - 1].Groups["password"].Value;

                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
            }
        }
    }
}
