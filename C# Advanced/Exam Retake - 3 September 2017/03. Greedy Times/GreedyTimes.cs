using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace _03.Greedy_Times
{
    class GreedyTimes
    {
        static void Main(string[] args)
        {
            var bagCapacity = long.Parse(Console.ReadLine());
            var freeCapacity = 0L;
            var inputList = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var goldList = new List<string>();
            var goldSum = new List<long>();
            var gemList = new List<string>();
            var gemSum = new List<long>();
            var cashList = new List<string>();
            var cashSum = new List<long>();

            for (int i = 0; i < inputList.Length; i+=2)
            {
                var item = inputList[i].ToLower();
                var quantity = long.Parse(inputList[i + 1]);

                if (freeCapacity + quantity <= bagCapacity)
                {
                    if (item.Contains("gold"))
                    {
                        goldList.Add(inputList[i]);
                        goldSum.Add(quantity);
                        freeCapacity += quantity;
                    }
                    else if (item.EndsWith("gem") && item.Length > 3 && goldSum.Sum() >= (gemSum.Sum() + quantity))
                    {
                        gemList.Add(inputList[i]);
                        gemSum.Add(quantity);
                        freeCapacity += quantity;
                    }
                    else if (item.Length == 3 && gemSum.Sum() >= (cashSum.Sum() + quantity))
                    {
                        cashList.Add(inputList[i]);
                        cashSum.Add(quantity);
                        freeCapacity += quantity;
                    }
                }
            }

            var dict = new Dictionary<string, Dictionary<string, long>>();

            dict["Gold"] = new Dictionary<string, long>();
            dict["Gold"].Add("Gold", goldSum.Sum());
        
            dict["Gem"] = new Dictionary<string, long>();
            for (int i = 0; i < gemList.Count; i++)
            {
                if (!dict["Gem"].ContainsKey(gemList[i]))
                {
                    dict["Gem"].Add(gemList[i], 0);
                }
                dict["Gem"][gemList[i]] += gemSum[i];
            }

            dict["Cash"] = new Dictionary<string, long>();

            for (int i = 0; i < cashList.Count; i++)
            {
                if (!dict["Cash"].ContainsKey(cashList[i]))
                {
                    dict["Cash"].Add(cashList[i], 0);
                }
                dict["Cash"][cashList[i]] += cashSum[i];
            }

            foreach (var item in dict.OrderByDescending(a => a.Value.Values.Sum()))
            {
                if (item.Value.Values.Count == 0)
                {
                    continue;
                }
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");

                foreach (var item2 in item.Value.OrderByDescending(a => a.Key).ThenBy(a => a.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}
