namespace _10.Predicate_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class PredicateParty
    {
        public static void Main()
        {
            var commingPeople = Console.ReadLine()
                .Split(new[] { ' ', '\t', '\n', 'r' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            ExecuteCommands(commingPeople);
            PrintCommingPeople(commingPeople);
        }

        static void PrintCommingPeople(List<string> commingPeople)
        {
            commingPeople.Sort();
            if (commingPeople.Any())
            {
                var names = string.Join(", ", commingPeople);
                Console.WriteLine($"{names} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static void ExecuteCommands(List<string> commingPeople)
        {
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                var commandTokens = command.Split().ToList();

                if (commandTokens.Count < 3)
                {
                    continue;
                }
                var action = commandTokens[0];
                var stratsOrEnds = commandTokens[1];
                var stringPartOfName = commandTokens[2];

                switch (stratsOrEnds)
                {
                    case "StartsWith":
                        ForEachName(action, commingPeople, n => n.StartsWith(stringPartOfName));
                        break;
                    case "EndsWith":
                        ForEachName(action, commingPeople, n => n.EndsWith(stringPartOfName));
                        break;
                    case "Length":
                        ForEachName(action, commingPeople, n => n.Length == int.Parse(stringPartOfName));
                        break;
                }
            }
        }

        static void ForEachName(string action, List<string> commingPeople, Func<string, bool> condition)
        {
            for (int i = commingPeople.Count - 1; i >= 0; i--)
            {
                if (condition(commingPeople[i]))
                {
                    switch (action)
                    {
                        case "Remove":
                            commingPeople.RemoveAt(i);
                            break;
                        case "Double":
                            commingPeople.Add(commingPeople[i]);
                            break;
                    }
                }
            }
        }
    }
}
