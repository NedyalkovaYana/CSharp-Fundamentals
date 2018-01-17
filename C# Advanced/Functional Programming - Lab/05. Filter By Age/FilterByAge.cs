namespace _05.Filter_By_Age
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class FilterByAge
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine()
                    .Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = inputs[0];
                var age = int.Parse(inputs[1]);

                if (!dict.ContainsKey(name))
                {
                    dict[name] = 0;
                }
                dict[name] = age;
            }

            var conditions = Console.ReadLine();
            var ages = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();
            var result = new Dictionary<string, int>();
            switch (conditions)
            {
                case "younger":
                    result = dict.Where(kvp => kvp.Value < ages).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    PrintResult(result, format);
                    break;
                case "older":
                    result = dict.Where(kvp => kvp.Value >= ages).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    PrintResult(result, format);
                    break;
            }

        }

        static void PrintResult(Dictionary<string, int> result, string format)
        {
            switch (format)
            {
                case "name":
                    foreach (var item in result)
                    {
                        Console.WriteLine($"{item.Key}");
                    }
                    break;
                case "age":
                    foreach (var item in result)
                    {
                        Console.WriteLine($"{item.Value}");
                    }
                    break;
                case "name age":
                    foreach (var item in result)
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                    break;
            }
        }
    }
}
