using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Treasure_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainRegex = new Regex(@"(#|!)(.*?)(?<a>[a-zA-Z]{4})(.*?)(?<s>\d{3}-\d{4,6})(.*?)(?=#|!)");
            

            string strN = string.Empty;
            string pass = string.Empty;
            string elem = string.Empty;
            string adddres = string.Empty;

            var listRezult = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();

                var mainMatch = Regex.Match(inputLine, @"(#|!)(.*?)(?<a>[a-zA-Z]{4})(.*?)(?<s>\d{3}-\d{4,6})(.*?)(?=#|!)", RegexOptions.RightToLeft);

                if (mainMatch.Success)
                {
                    var addres = mainMatch.Groups["a"].Value;
                    var street = mainMatch.Groups["s"].Value;

                    if (adddres.Length > 0 && street.Length > 0)
                    {
                        if (!listRezult.ContainsKey(adddres))
                        {
                            listRezult.Add(addres, street);
                        }
                    }
                }
                       
                if (listRezult.Count == 0)
                {
                    continue;
                }
                else
                {
                    var counts = listRezult.Count;

                    if (counts == 1)
                    {
                        var listIndex = 0;
                        GetResult(ref strN, ref pass, listRezult, listIndex, adddres);
                    }
                    else if (counts % 2 == 0)
                    {
                        var listIndex = counts / 2;
                        GetResult(ref strN, ref pass, listRezult, listIndex, adddres);
                    }
                    else if (counts % 2 != 0)
                    {
                        var listIndex = counts / 2;
                        GetResult(ref strN, ref pass, listRezult, listIndex, adddres);
                    }
                }
                listRezult.Clear();
            }
        }

        private static void GetResult(ref string strN, ref string pass, Dictionary<string, string> listRezult, int listIndex, string adddres)
        {
            var counter = 0;
            foreach (var elem in listRezult)
            {
                if (counter == listIndex)
                {
                    adddres = elem.Key;
                    PrintResult(out strN, out pass, listRezult, elem.Value, adddres);
                    break;
                }
                counter++;
            }
        }

        private static void PrintResult(out string strN, out string pass, Dictionary<string, string> listRezult, string elem, string adddres)
        {
            GetElements(listRezult, out strN, out pass, elem);
            Console.Write($"Go to str. {adddres} {strN}.");
            Console.Write($" Secret pass: {pass}.");
            Console.WriteLine();
        }

        private static void GetElements(Dictionary<string, string> listRezult, out string strN, out string pass, string elem)
        {
            var tokens = elem.Split('-').ToList();
            strN = tokens[0];
            pass = tokens[1];
        }
    }
}
