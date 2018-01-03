namespace _03.CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountSameValuesInArray
    {
        static void Main()
        {
            var occurranceDict = new SortedDictionary<double, int>();

            var inputArray = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (!occurranceDict.ContainsKey(inputArray[i]))
                {
                    occurranceDict.Add(inputArray[i], 0);
                }
                occurranceDict[inputArray[i]] += 1;
            }

            foreach (var occurrance in occurranceDict)
            {
                Console.WriteLine($"{occurrance.Key} - {occurrance.Value} times");
            }
        }
    }
}
