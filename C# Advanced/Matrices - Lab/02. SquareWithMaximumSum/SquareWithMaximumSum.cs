using System.Linq;

namespace _02.SquareWithMaximumSum
{
    using System;
    using System.Collections.Generic;
    public class SquareWithMaximumSum
    {
       public static void Main()
        {
            var matrix = GetMatrixFromConsole();

            FindMaxSum(matrix);
        }

        private static void FindMaxSum(int[][] matrix)
        {
            var bestSum = int.MinValue;
            var sum = 0;
            var bestRow = 0;
            var bestCol = 0;

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    sum = matrix[row][col] 
                        + matrix[row][col + 1]
                        + matrix[row + 1][col] 
                        + matrix[row + 1][col + 1];

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            PrintResult(matrix, bestCol, bestRow, bestSum);
        }

        static void PrintResult(int[][] matrix, int bestCol, int bestRow, int bestSum)
        {
            Console.WriteLine($" {matrix[bestRow][bestCol]} {matrix[bestRow][bestCol + 1]}");
            Console.WriteLine($" {matrix[bestRow + 1][bestCol]} {matrix[bestRow + 1][bestCol + 1]}");
            Console.WriteLine(bestSum);
        }

        static int[][] GetMatrixFromConsole()
        {
            var dimentions = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = dimentions[0];
            var cols = dimentions[1];

            var matrix = new int[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Take(cols)
                    .ToArray();
            }

            return matrix;
        }
    }
}
