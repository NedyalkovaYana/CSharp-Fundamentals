using System.ComponentModel;

namespace _04.Find_Evens_or_Odds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class FindEvensOrOdds
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var start = input[0];
            var end = input[1];

            var targetNumbers = Console.ReadLine().Trim().ToLower();
            Predicate<int> predicate;

            switch (targetNumbers)
            {
                case "odd":
                     predicate = n => n % 2 != 0;
                    break;
                case "even":
                    predicate = n => n % 2 == 0;
                    break;
                    default:
                        predicate =  null;
                        break;
            }

            var result = EventsOrOdd(start, end, predicate);
            Console.WriteLine(string.Join(" ", result));
        }

        static Queue<int> EventsOrOdd(int start, int end, Predicate<int> predicate)
        {
            var numbers = new Queue<int>();

            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                {
                    numbers.Enqueue(i);
                }   
            }
            return numbers;
        }
    }
}
