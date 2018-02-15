using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.Jedi_Galaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger sum = 0;
            var dimentions = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = InitializeMatrix(dimentions);

            sum = GetIvoScore(matrix, dimentions, sum);

            Console.WriteLine(sum);
        }

        static BigInteger GetIvoScore(List<List<int>> matrix, int[] dimentions, BigInteger sum)
        {
            var inputCoordinate = string.Empty;
            while ((inputCoordinate = Console.ReadLine()) != "Let the Force be with you")
            {
                var tokensIvo = inputCoordinate
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var ivoStartRow = tokensIvo[0];
                var ivoSTartCol = tokensIvo[1];

                var evilTokens = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var evilStartRow = evilTokens[0];
                var evilStartCol = evilTokens[1];
              

               DestroyedMatrix(matrix, evilStartRow, evilStartCol, dimentions);
               sum = GetPoints(ivoStartRow, ivoSTartCol, matrix, sum, dimentions);
            }
            return sum;
        }

        static BigInteger GetPoints(int row, int col, List<List<int>> matrix, BigInteger sum, int[] dimentions)
        {
            while (row >= 0 && col < matrix[0].Count)
            {
                if (IsInMatrix(matrix, row, col))
                {
                    sum += matrix[row][col];
                }

                row--;
                col++;
            }
            return sum;
        }

        static bool IsInMatrix(List<List<int>> matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.Count && col < matrix[row].Count;
        }

        static void DestroyedMatrix(List<List<int>> matrix, int row, int col, int[] dimentions)
        {
            while (row >= 0 && col >= 0)
            {
                if (IsInMatrix(matrix, row, col))
                {
                    matrix[row][col] = 0;
                }

                row--;
                col--;
            }
        }
        static List<List<int>> InitializeMatrix(int[] dimentions)
        {
            var rows = dimentions[0];
            var cols = dimentions[1];

            var matrix = new List<List<int>>();
            var cellValue = 0;
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix.Add(new List<int>());
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex].Add(cellValue);
                    cellValue++;
                }
            }
            return matrix;
        }
    }
}
