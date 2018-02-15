using System.Text;
using System.Text.RegularExpressions;

namespace _04.Jedi_Dreams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            var regexStaticMethod = new Regex(@"static\s+.*\s+(?<key>[a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(");
            var regexForInvoke = new Regex(@"(?<m>[a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(");

            var staticMethod = string.Empty;
            int n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                var inputLines = Console.ReadLine();

                var match = regexStaticMethod.Match(inputLines);

                if (match.Success)
                {
                    staticMethod = match.Groups["key"].Value;
                    if (!dict.ContainsKey(staticMethod))
                    {
                        dict[staticMethod] = new List<string>();
                    }
                }
                else
                {
                    var matches = regexForInvoke.Matches(inputLines);
                    foreach (Match item in matches)
                    {
                        var invokeMethod = item.Groups["m"].Value;
                        dict[staticMethod].Add(invokeMethod);
                    }
                }

            }

            
            foreach (var item in dict.OrderByDescending(a => a.Value.Count).ThenBy(a => a.Key))
            {
                if (item.Value.Count > 0)
                {
                    Console.Write($"{item.Key} -> {item.Value.Count} -> {string.Join(", ", item.Value.OrderBy(a => a))}");
                  
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{item.Key} -> None");
                }
                
            }
        }
    }
}
