using System.Runtime.InteropServices;

namespace _09.List_Of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class ListOfPredicates
    {
        static void Main()
        {
            var endNumber = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine()
                .Split(new[] {' ', '\t', '\n', 'r'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct();
                
            var numbers = new Queue<int>();

            var predicates = dividers
                .Select(div => (Func<int, bool>)(n => n % div == 0))
                .ToArray();

            for (int i = 1; i <= endNumber; i++)
            {
                if (IsValid(predicates, i))
                {
                    numbers.Enqueue(i);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
        static bool IsValid(Func<int, bool>[] predicates, int i)
        {
            foreach (var predicate in predicates)
            {
                if (!predicate(i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
