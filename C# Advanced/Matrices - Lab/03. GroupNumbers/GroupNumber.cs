using System.Linq;

namespace _03.GroupNumbers
{
    using System;
    using System.Collections.Generic;
    class GroupNumber
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var sizes = new int[3];

            foreach (var number in numbers)
            {
                int remainder = number % 3;
                sizes[Math.Abs(remainder)]++;
            }

            int[][] matrix =
            {
                new int[sizes[0]],
                new int[sizes[1]],
                new int[sizes[2]]
            };

            int[] offsets = new int[3];

            foreach (var number in numbers)
            {
                int remainder = number % 3;
                int index = offsets[Math.Abs(remainder)];
                matrix[Math.Abs(remainder)][index] = number;
                offsets[Math.Abs(remainder)]++;

            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                foreach (var num in matrix[row])
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
          
        }
    }
}
