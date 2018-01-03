using System.Text.RegularExpressions;

namespace _13.Srabsko_Unleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class SrabskoUnleashed
    {
        public static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, long>>();

            var pattern = @"(?<singerName>.*?)\s@(?<town>.*?)\s(?<price>\d+)\s(?<count>\d+)";
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var matches = Regex.Match(input, pattern);

                if (matches.Success)
                {
                    var singer = matches.Groups["singerName"].Value;
                    var town = matches.Groups["town"].Value;
                    var price = int.Parse(matches.Groups["price"].Value);
                    var count = int.Parse(matches.Groups["count"].Value);

                    if (!dict.ContainsKey(town))
                    {
                        dict[town] = new Dictionary<string, long>();
                    }
                    if (!dict[town].ContainsKey(singer))
                    {
                        dict[town].Add(singer, 0);
                    }
                    dict[town][singer] += count * price;
                }
            }

            foreach (var town in dict.OrderByDescending(a => a.Value.Values.Count))
            {
                Console.WriteLine($"{town.Key}");
                foreach (var singer in town.Value.OrderByDescending(a => a.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
