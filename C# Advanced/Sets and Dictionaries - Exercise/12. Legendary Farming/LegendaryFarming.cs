namespace _12.Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class LegendaryFarming
    {
        public static void Main()
        {
            var legendary = new Dictionary<string, int>();
            var jurk = new Dictionary<string, int>();

            legendary.Add("shards", 0);
            legendary.Add("fragments", 0);
            legendary.Add("motes", 0);
            bool notEnoughMaterial = true;

            while (notEnoughMaterial)
            {
                var input = Console.ReadLine()
                    .ToLower()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                for (int i = 0; i < input.Count; i+= 2)
                {
                    var mark = int.Parse(input[i]);
                    var material = input[i + 1];

                    if (legendary.ContainsKey(material))
                    {
                        legendary[material] += mark;
                        if (legendary[material] >= 250)
                        {
                            legendary[material] -= 250;
                            var result = string.Empty;
                            switch (material)
                            {
                                case "shards": result = "Shadowmourne"; break;
                                case "fragments": result = "Valanyr"; break;
                                case "motes": result = "Dragonwrath"; break;
                            }
                            Console.WriteLine("{0} obtained!", result);
                            notEnoughMaterial = false;
                            break;
                        }
                    }                 
                    else 
                    {
                        if (!jurk.ContainsKey(material))
                            jurk[material] = 0;
                        jurk[material] += mark;
                       
                    }
                    
                }

            }
            PrintResult(legendary, jurk);
        }

        static void PrintResult(Dictionary<string, int> legendary, Dictionary<string, int> jurk)
        {
            foreach (var materials in legendary.OrderByDescending(a => a.Value).ThenBy(a => a.Key))
            {
                Console.WriteLine($"{materials.Key}: {materials.Value} ");
            }

            foreach (var materials in jurk.OrderBy(a => a.Key))
            {
                Console.WriteLine($"{materials.Key}: {materials.Value} ");
            }
        }
    }
}
