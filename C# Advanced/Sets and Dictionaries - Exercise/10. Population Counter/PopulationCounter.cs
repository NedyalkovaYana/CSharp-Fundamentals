namespace _10.Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PopulationCounter
    {
        static void Main()
        {
            var countryPopulationDict = new Dictionary<string, Dictionary<string, long>>();

            var inputPopulations = string.Empty;

            while ((inputPopulations = Console.ReadLine()) != "report")
            {
                var tokens = inputPopulations
                    .Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var country = tokens[1];
                var city = tokens[0];
                var population = long.Parse(tokens[2]);

                if (!countryPopulationDict.ContainsKey(country))
                {
                    countryPopulationDict[country] = new Dictionary<string, long>();
                }
                if (!countryPopulationDict[country].ContainsKey(city))
                {
                    countryPopulationDict[country].Add(city, 0);
                }
                countryPopulationDict[country][city] += population;

            }

            foreach (var countryes in countryPopulationDict.OrderByDescending(a => a.Value.Values.Sum()))
            {
                Console.WriteLine($"{countryes.Key} (total population: {countryes.Value.Values.Sum()})");

                foreach (var cities in countryes.Value.OrderByDescending(a => a.Value))
                {
                    Console.WriteLine($"=>{cities.Key}: {cities.Value}");
                }
            }
        }
    }
}
