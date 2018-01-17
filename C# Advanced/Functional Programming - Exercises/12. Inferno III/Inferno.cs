namespace _12.Inferno_III
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Inferno
    {
        public static void Main()
        {
            var gems = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            ExecuteCommands(gems);

            Console.WriteLine(string.Join(" ", gems));
        }

        static void ExecuteCommands(List<int> gems)
        {
            var commands = Console.ReadLine()
                .Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var exclusionFilter = new Queue<KeyValuePair<string, int>>();

            while (commands[0] != "Forge")
            {
                var command = commands[0];
                var type = commands[1];
                var parameter = int.Parse(commands[2]);

                switch (command)
                {
                    case "Exclude":
                        exclusionFilter.Enqueue(new KeyValuePair<string, int>(type, parameter));
                        break;
                    case "Reverse":
                        if (exclusionFilter.Count > 0)
                        {
                            exclusionFilter.Dequeue();
                        }
                        break;
                }
                commands = Console.ReadLine()
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }
            ExecuteExclusions(gems, exclusionFilter);
        }

        static void ExecuteExclusions(List<int> gems, Queue<KeyValuePair<string, int>> exclusionFilter)
        {
            foreach (var filter in exclusionFilter.Reverse())
            {
                switch (filter.Key)
                {
                    case "Sum Left":
                        FilterLeft(filter.Value, gems);
                        break;
                    case "Sum Right":
                        FilterRight(filter.Value, gems);
                        break;
                    case "Sum Left Right":
                        FilterLeftRight(filter.Value, gems);
                        break;
                }
            }
        }

        static void FilterLeftRight(int filterValue, List<int> gems)
        {
            for (int i = 0; i < gems.Count; i++)
            {
                var leftGemPower = (i == 0) ? 0 : gems[i - 1];
                var rightGemPower = (i == gems.Count - 1) ? 0 : gems[i + 1];

                if (leftGemPower + gems[i] + rightGemPower == filterValue)
                {
                    gems.RemoveAt(i);
                    i--;
                }
            }
        }

        static void FilterRight(int filterValue, List<int> gems)
        {
            while (gems.Count > 0 && gems.Last() == filterValue)
            {
                gems.RemoveAt(gems.Count - 1);
            }

            for (int i = 0; i < gems.Count; i++)
            {
                var rightNum = (i == gems.Count - 1) ? 0 : gems[i + 1];

                if (gems[i] + rightNum == filterValue)
                {
                    gems.RemoveAt(i);
                    i--;
                }
            }
        }

        static void FilterLeft(int filterValue, List<int> gems)
        {
            while (gems.Count > 0 && gems.First() == filterValue)
            {
                gems.RemoveAt(0);
            }
            for (int i = gems.Count - 1; i >= 0; i--)
            {
                var leftNum = (i > 0) ? gems[i - 1] : 0;
                if (gems[i] + leftNum == filterValue)
                {
                    gems.RemoveAt(i);
                }
            }
        }
    }
}
