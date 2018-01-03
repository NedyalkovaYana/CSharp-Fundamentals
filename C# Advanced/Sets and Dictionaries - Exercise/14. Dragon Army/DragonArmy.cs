

namespace _14.Dragon_Army
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class DragonArmy
    {

        static void Main()
        {
            var dragonDict = new Dictionary<string, SortedDictionary<string, int[]>>();
            var regex = new Regex
                (@"(?<type>[a-zA-Z]*)\s*(?<name>[a-zA-Z]*)\s*(?<damage>null|\d+)\s*(?<health>null|\d+)\s*(?<armor>null|\d+)");

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var match = regex.Match(input);

                if (match.Success)
                {
                    var type = match.Groups["type"].Value;
                    var name = match.Groups["name"].Value;
                    var damage = 0;
                    var health = 0;
                    var armor = 0;
                    damage = match.Groups["damage"]
                        .Value == "null" ? 45 : int.Parse(match.Groups["damage"].Value);
                    health = match.Groups["health"]
                        .Value == "null" ? 250 : int.Parse(match.Groups["health"].Value);
                    armor = match.Groups["armor"]
                                .Value == "null" ? 10 : int.Parse(match.Groups["armor"].Value);

                    if (!dragonDict.ContainsKey(type))
                    {
                        dragonDict[type] = new SortedDictionary<string, int[]>();
                    }
                    if (!dragonDict[type].ContainsKey(name))
                    {
                        dragonDict[type][name] = new int[3];
                    }
                    dragonDict[type][name][0] = damage;
                    dragonDict[type][name][1] = health;
                    dragonDict[type][name][2] = armor;
                }
            }

            foreach (var types in dragonDict)
            {
                Console.WriteLine($"{types.Key}::({types.Value.Select(x => x.Value[0]).Average():f2}/" +
                                  $"{types.Value.Select(a => a.Value[1]).Average():f2}/" +
                                  $"{types.Value.Select(a => a.Value[2]).Average():f2})");

                foreach (var dragons in types.Value)
                {
                    Console.WriteLine($"-{dragons.Key} -> damage: {dragons.Value[0]}, " +
                                      $"health: {dragons.Value[1]}, " +
                                      $"armor: {dragons.Value[2]}");
                }
            }
        }
    }
}
