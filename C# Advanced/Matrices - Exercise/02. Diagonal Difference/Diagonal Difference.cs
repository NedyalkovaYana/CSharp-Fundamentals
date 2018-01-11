using System.Linq;

namespace _02.Diagonal_Difference
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new long[n][];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var inputsCols = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
                matrix[i] = inputsCols;
            }

            var primaryDiagonalSum = 0L;
            var secondaryDiagonalSum = 0L;

            // calculate the sum of primary diagonal (right)
            for (int row = 0; row < n; row++)
            {
                primaryDiagonalSum += matrix[row][row];
            }

            // calculate the sun of secondary diagonal (left)

            for (int row = 0, col = n - 1; row < n; row++, col--)
            {
                secondaryDiagonalSum += matrix[row][col];
            }
            Console.WriteLine($"{Math.Abs(primaryDiagonalSum - secondaryDiagonalSum)}");
        }
    }
}
