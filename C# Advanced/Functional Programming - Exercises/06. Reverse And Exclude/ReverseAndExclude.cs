namespace _06.Reverse_And_Exclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class ReverseAndExclude
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var divisor = int.Parse(Console.ReadLine());

            Func<int, bool> filter = n => n % divisor != 0;

            var result = numbers.Reverse().Where(filter);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
