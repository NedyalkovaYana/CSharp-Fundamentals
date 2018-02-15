using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Jedi_Code_X
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var savedStrings = new List<string>();

            for (int i = 0; i < n; i++)
            {
               savedStrings.Add(Console.ReadLine().Trim());
            }

            var firstPattern = Console.ReadLine();
            var secondPattern = Console.ReadLine();

            var indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var regex = new Regex($@"{firstPattern}(?<name>[a-zA-z]+)");

            var matchedNames = new List<string>();
            for (int i = 0; i < savedStrings.Count; i++)
            {
                MatchCollection matches = regex.Matches(savedStrings[i]);
                foreach (Match item in matches)
                {
                    var name = item.Groups["name"].Value;
                    if (firstPattern.Length == name.Length)
                    {
                        matchedNames.Add(name);
                    }
                   
                }
            }

            var secondRegex = new Regex($@"{secondPattern}(?<message>[0-9a-zA-Z]+)");
            var matchedMessages = new List<string>();
            for (int i = 0; i < savedStrings.Count; i++)
            {
                MatchCollection matchM = secondRegex.Matches(savedStrings[i]);

                foreach (Match item in matchM)
                {
                    var message = item.Groups["message"].Value;
                    if (secondPattern.Length == message.Length)
                    {
                        matchedMessages.Add(message);
                    }
                }
            }

            var result = new List<string>();

            for (int i = 0; i < matchedNames.Count; i++)
            {
                if (indexes.Length - 1 <  i )
                {
                    break;
                }
                var number = indexes[i] - 1;
                var messagess = string.Empty;
               if (number > matchedMessages.Count - 1)
               {
                   break;
               }
                messagess = matchedMessages[number];

                var strings = matchedNames[i] + " - " + messagess;

                result.Add(strings);
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
