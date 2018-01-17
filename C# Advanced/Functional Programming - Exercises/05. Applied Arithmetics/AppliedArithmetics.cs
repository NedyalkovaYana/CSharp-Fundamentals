namespace _05.Applied_Arithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var command = string.Empty;

            while ((command = Console.ReadLine().Trim().ToLower()) != "end")
            {
                switch (command)
                {
                    case "add": // add 1 to  each number
                        numbers = ForEach(numbers, n => n + 1);
                        break;
                    case "subtract": // substract 1 from each number
                        numbers = ForEach(numbers, n => n - 1);
                        break;
                    case "multiply": // multiply each number by 2
                        numbers = ForEach(numbers, n => n * 2);
                        break;
                    case "print": // print collection
                        Console.WriteLine(string.Join(" ", numbers));
                        break;

                }
            }

        }

        public static IEnumerable<int> ForEach(IEnumerable<int> collection, Func<int, int>func)
        {
            return collection.Select(n => func(n));
        }
    }
}
