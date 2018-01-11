namespace _09.Crossfire
{
    using System;
    using System.Linq;
    class Crossfire
    {
        static void Main()
        {
            var matrix = InitializeMatrix();
            matrix = ExecuteCommands(matrix);
            PrintAliveCells(matrix);
        }

        static void PrintAliveCells(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine
                    (string.Join(" ", matrix[i]
                    .Where(c => c != -1)));
            }
        }

        static int[][] ExecuteCommands(int[][] matrix)
        {
            var commands = Console.ReadLine().Trim();

            while (commands != "Nuke it from orbit")
            {
                var commandDetails = commands
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var hitRow = commandDetails[0];
                var hitColumn = commandDetails[1];
                var hitWaveRadius = commandDetails[2];

                matrix = DestroyMatrix(matrix, hitRow, hitWaveRadius, hitColumn);

                commands = Console.ReadLine().Trim();
            }
            return matrix;
        }

        static int[][] DestroyMatrix(int[][] matrix, int hitRow, int hitWaveRadius, int hitCol)
        {
            // Mark destroyed part of the column
            for (int row = hitRow - hitWaveRadius; row <= hitRow + hitWaveRadius; row++)
            {
                if (IsInMatrix(row, hitCol, matrix))
                {
                    matrix[row][hitCol] = -1;
                }
            }

            // Mark destroyed part of the row
            for (int col = hitCol - hitWaveRadius; col <= hitCol + hitWaveRadius; col++)
            {
                if (IsInMatrix(hitRow, col, matrix))
                {
                    matrix[hitRow][col] = -1;
                }
            }

            // Remove destroyed cells
            for (int i = 0; i < matrix.Length; i++)
            {
                // Remove destroyed cells if there is ones
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < 0)
                    {
                        matrix[i] = matrix[i]
                            .Where(n => n > 0).ToArray();
                        break;
                    }
                }

                // Remove empty rows
                if (matrix[i].Count() < 1)
                {
                    matrix = matrix.Take(i)
                        .Concat(matrix.Skip(i + 1)).ToArray();
                    i--;
                }
            }
            return matrix;
        }

        static bool IsInMatrix(int row, int col, int[][] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }

        static int[][] InitializeMatrix()
        {
            var dimentions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var rows = dimentions[0];
            var columns = dimentions[1];
            var matrix = new int[rows][];
            var currentCellNumber = 1;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[columns];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = currentCellNumber;
                    currentCellNumber++;
                }
            }
            return matrix;
        }
    }
}
