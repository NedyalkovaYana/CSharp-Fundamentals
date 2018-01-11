

using System.CodeDom;

namespace _04.Maximal_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            var inputsCoordinates = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = inputsCoordinates[0];
            var columns = inputsCoordinates[1];

            var matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var bestSum = int.MinValue;
            
            int[,] bestMatrix = new int[3, 3];
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < columns - 2; col++)
                {
                    var currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2]
                                     + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2]
                                     + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];
                    if (bestSum < currentSum)
                    {
                        bestSum = currentSum;
                       bestMatrix = new int[,]
                        {
                           { matrix[row][col], matrix[row][col + 1], matrix[row][col + 2]},
                           { matrix[row + 1][col], matrix[row + 1][col + 1], matrix[row + 1][col + 2] },
                           { matrix[row + 2][col],  matrix[row + 2][col + 1], matrix[row + 2][col + 2]}
                        };
                    }
                }
            }

            Console.WriteLine($"Sum = {bestSum}");

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"{bestMatrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
