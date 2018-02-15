using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Shmoogle_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            var regexDouble = new Regex(@"double\s+(?<d>[a-zA-Z]+)");
            var regexInt = new Regex(@"int\s+(?<i>[a-zA-Z]+)");
            var doubles = new List<string>();
            var ints = new List<string>();

            var inputs = string.Empty;
            while ((inputs = Console.ReadLine()) != "//END_OF_CODE")
            {
                if (inputs.Contains("double"))
                {
                    var matchR = regexDouble.Match(inputs);
                    if (matchR.Success)
                    {
                        var words = matchR.Groups["d"].Value.ToCharArray();
                        if (Char.IsUpper(words[0]))
                        {
                            continue;
                            
                        }
                        doubles.Add(matchR.Groups["d"].Value);

                    }
                }
                else if (inputs.Contains("int"))
                {
                    var matchI = regexInt.Match(inputs);
                    if (matchI.Success)
                    {
                        var word = matchI.Groups["i"].Value.ToCharArray();
                        if (Char.IsUpper(word[0]))
                        {
                            continue;
                        }
                        ints.Add(matchI.Groups["i"].Value);
                    }
                }
            }

            if (doubles.Count > 0)
            {
                doubles.Sort();
                Console.WriteLine($"Doubles: {string.Join(", ", doubles)}");
            }
            else
            {
                Console.WriteLine("Doubles: None");
            }
            if (ints.Count > 0)
            {
                ints.Sort();
                Console.WriteLine($"Ints: {string.Join(", ", ints)}");
            }
            else
            {
                Console.WriteLine("Ints: None");
            }
        }
    }
}
