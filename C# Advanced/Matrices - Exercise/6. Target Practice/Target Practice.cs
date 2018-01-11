namespace _6.Target_Practice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
           char[,] matrix = ReadAndFillMatrix();

            ShotSnakes(matrix);

            PrintResult(matrix);
        }

        static void PrintResult(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void ShotSnakes(char[,] matrix)
        {
            var shots = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var shotRow = shots[0];
            var shotCol = shots[1];
            var radius = shots[2];

            for (int row = 0; row < matrix.GetLength(0); row++) // Process shot impact
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (IsCellShooted(row, col, shotRow, shotCol, radius))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = matrix.GetLength(0) - 1; row > 0; row--)
                {
                    if (matrix[row, col] == ' ' && matrix[row - 1, col] != ' ')
                    {
                        CellFallsDown(matrix, row, col);
                    }
                }
            }


        }

        static void CellFallsDown(char[,] matrix, int row, int col)
        {
            while (row < matrix.GetLength(0))
            {
                if (matrix[row, col] == ' ')
                {
                    var temp = matrix[row - 1, col];
                    matrix[row - 1, col] = matrix[row, col];
                    matrix[row, col] = temp;
                    row++;
                }
                else
                {
                    return;
                }
            }
        }

        static bool IsCellShooted(int row, int col, int shotRow, int shotCol, int radius)
        {
            var distance = Math.Sqrt((row - shotRow) * (row - shotRow) 
                + (col - shotCol) * (col - shotCol));
            return distance <= radius;
        }

        static char[,] ReadAndFillMatrix()
        {
            var inputs = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = inputs[0];
            var columns = inputs[1];

            var matrix = new char[rows, columns];
            var currentFilledIndex = 0;
            var filledValue = Console.ReadLine()
                .ToCharArray();

            var directionToFill = 0;

            for (int row = rows - 1; row >= 0; row--)
            {
                if (directionToFill % 2 != 0)
                {
                    for (int col = 0; col <= columns - 1; col++)
                    {
                        matrix[row, col] = filledValue[currentFilledIndex];
                        currentFilledIndex++;
                        if (currentFilledIndex >= filledValue.Length)
                        {
                            currentFilledIndex = 0;
                        }
                    }
                    directionToFill++;
                }
                else
                {
                    for (int col = columns - 1; col >= 0; col--)
                    {
                        matrix[row, col] = filledValue[currentFilledIndex];
                        currentFilledIndex++;
                        if (currentFilledIndex >= filledValue.Length)
                        {
                            currentFilledIndex = 0;
                        }
                    }
                    directionToFill++;
                }
                    
            }
            return matrix;
        }
    }
}
