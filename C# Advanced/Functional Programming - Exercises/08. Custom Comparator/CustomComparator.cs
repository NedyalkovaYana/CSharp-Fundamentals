namespace _08.Custom_Comparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class CustomComparator
    {
        static void Main()
        {
            var inputNums = Console.ReadLine()
                .Split(new[] {' ', '\t', '\n', 'r'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var evenNums = new List<int>();
            var oddNums = new List<int>();

            Predicate<int> predicate = n => n % 2 == 0;

            EventOrOdd(inputNums, predicate, evenNums, oddNums);

            evenNums.Sort();
            oddNums.Sort();

            var result = new List<int>();
            result.AddRange(evenNums);
            result.AddRange(oddNums);

            Console.WriteLine(string.Join(" ", result));
        }

        public static void EventOrOdd (List<int> collection, 
            Predicate<int> predicate, List<int> evenNums, List<int> oddNums)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (predicate(collection[i]))
                {
                    evenNums.Add(collection[i]);
                }
                else
                {
                    oddNums.Add(collection[i]);
                }
            }
        }
    }
}
