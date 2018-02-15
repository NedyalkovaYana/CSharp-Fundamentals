using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Collect_Resources
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputMetals = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var collectedElement = new Dictionary<string, long>();
            var resourse = string.Empty;
            var quantity = 0;
            var numbersOfVariant = int.Parse(Console.ReadLine());
            var savedResult = new List<long>();
            var count = 0;

            for (int i = 0; i < numbersOfVariant; i++)
            {
                var startAndSteps = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var startPosition = int.Parse(startAndSteps[0]);
                var steps = int.Parse(startAndSteps[1]);

                for (int j = startPosition; j < inputMetals.Length; j+= steps)
                {
                    
                    var containsInt = inputMetals[j].Any(char.IsDigit);
                    if (!containsInt)
                    {
                        resourse = inputMetals[i];
                        quantity = 1;
                    }
                    else
                    {
                        var tokens = inputMetals[j].Split(new[] {'_'}, StringSplitOptions.RemoveEmptyEntries);
                        resourse = inputMetals[i];
                        quantity = int.Parse(tokens[1]);
                    }
                    if (resourse.ToLower() == "stone" || resourse.ToLower() == "gold" || resourse.ToLower() == "wood" || resourse.ToLower() == "food")
                    {
                        if (!collectedElement.ContainsKey(resourse))
                        {
                            collectedElement[resourse] = quantity;
                        }
                        else
                        {
                            var totalSum = collectedElement.Values.Sum();
                            savedResult.Add(totalSum);
                            collectedElement.Clear();
                            break;
                        }
                    }
                    if ((j + steps) > inputMetals.Length - 1)
                    {
                        count = (inputMetals.Length - 1) - j;
                        j = -count - 1;
                    }
                }

            }

            Console.WriteLine($"{savedResult.Max()}");
        }
    }
}
