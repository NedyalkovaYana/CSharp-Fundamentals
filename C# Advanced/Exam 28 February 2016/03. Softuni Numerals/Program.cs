using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03.Softuni_Numerals
{
    class Program
    {
        static void Main(string[] args)
        {
            var digit = new string[]
            {
                "aa", "aba", "bcc", "cc", "cdc"
            };

            var inputString = Console.ReadLine();
            var convertedString = ConvertToBaseFive(digit, inputString);
            Console.WriteLine(ConvertFromBase5ToBase10(convertedString));
        }

        private static BigInteger ConvertFromBase5ToBase10(string convertedString)
        {
            return convertedString.Select(digit => (int)digit - 48).Aggregate(0, (x, y) => x * 5 + y);
        }

        private static string ConvertToBaseFive(string[] digit, string inputString)
        {
            var result = string.Empty;

            while (inputString.Length > 0)
            {
                for (int i = 0; i < digit.Length; i++)
                {
                    if (inputString.StartsWith(digit[i]))
                    {
                        result += i;
                        inputString = inputString.Substring(digit[i].Length);
                        break;
                    }
                }
            }
            return result;
        }
    }
}
