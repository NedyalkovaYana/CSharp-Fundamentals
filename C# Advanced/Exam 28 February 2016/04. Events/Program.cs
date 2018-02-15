using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, List<string>>>();
            var regex = new Regex(
                @"^#(?<person>[a-zA-Z]+):\s*@(?<location>[a-zA-Z]+)\s*(?<h>(\d+){1,2}):(?<m>(\d+){2})");

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var matches = regex.Matches(Console.ReadLine());

                foreach (Match item in matches)
                {
                    var person = item.Groups["person"].Value;
                    var location = item.Groups["location"].Value;
                    var hours = item.Groups["h"].Value;
                    var minutes = item.Groups["m"].Value;

                    var checkHour = int.Parse(hours);
                    var checkMin = int.Parse(minutes);
                    if (checkHour < 0 || checkHour > 23)
                    {
                        continue;
                    }
                    if (checkMin < 0 || checkMin > 59)
                    {
                        continue;
                    }

                    if (!dict.ContainsKey(location))
                    {
                        dict[location] = new Dictionary<string, List<string>>();
                        
                    }
                    if (!dict[location].ContainsKey(person))
                    {
                        dict[location][person] = new List<string>();
                    }
                    string hour = hours + ":" + minutes;
                    dict[location][person].Add(hour);
                }
            }
            var locations = Console.ReadLine()
                .Split(new string[] {",", " "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            locations.Sort();
            
            foreach (var city in locations)
            {
                foreach (var item in dict.OrderBy(a => a.Key))
                {
                    if (item.Key == city)
                    {
                        var count = 1;
                        Console.WriteLine($"{item.Key}:");
                        foreach (var person in item.Value.OrderBy(a => a.Key))
                        {
                            Console.WriteLine($"{count}. {person.Key} -> {string.Join(", ", person.Value.OrderBy(a => a))}");
                            count++;
                        }
                    }
                }
            }

        }
    }
}
