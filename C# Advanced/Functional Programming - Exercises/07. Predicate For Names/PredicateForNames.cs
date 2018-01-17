namespace _07.Predicate_For_Names
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class PredicateForNames
    {
        static void Main()
        {
            var targetLength = int.Parse(Console.ReadLine());
            var personNames = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            Print(personNames, name => name.Length <= targetLength);
        }

        public static void Print(IEnumerable<string> persons, Func<string, bool> filter)
        {
            Console.WriteLine(string.Join(Environment.NewLine, persons.Where(filter)));
        }
    }
}
