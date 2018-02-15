using System.Linq;
using System.Net;

namespace _04.Cubic_Assault
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        public static int ConvertThreshold = 1_000_000;
        static void Main()
        {
            var meteorNames = new List<string>() {"Green", "Red", "Black"};
            var dict = new Dictionary<string, Dictionary<string, long>>();

            var inputLines = String.Empty;
            while ((inputLines = Console.ReadLine()) != "Count em all")
            {
                var tokens = inputLines
                    .Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);

                var regionName = tokens[0];
                var meteorType = tokens[1];
                var meteorCount = long.Parse(tokens[2]);

                if (!dict.ContainsKey(regionName))
                {
                    dict[regionName] =
                        new Dictionary<string, long>()
                        { {"Green", 0}, {"Red", 0}, {"Black", 0}};
                }

                dict[regionName][meteorType] += meteorCount;

                for (int i = 0; i < meteorNames.Count - 1; i++)
                {
                    var nextTypeCount = 
                        dict[regionName][meteorNames[i]] / ConvertThreshold;

                    if (nextTypeCount > 0)
                    {
                        dict[regionName][meteorNames[i + 1]] += nextTypeCount;
                        dict[regionName][meteorNames[i]] %= ConvertThreshold;
                    }
                }            
            }
            var orderedRegions = dict
                .OrderByDescending(r => r.Value["Black"])
                .ThenBy(a => a.Key.Length)
                .ThenBy(r => r.Key)
                .ToDictionary(r => r.Key, r => r.Value);

            foreach (var region in orderedRegions)
            {
                Console.WriteLine(region.Key);
                foreach (var meteor in region.Value
                    .OrderByDescending(m => m.Value)
                    .ThenBy(a => a.Key))
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }
    }
}
