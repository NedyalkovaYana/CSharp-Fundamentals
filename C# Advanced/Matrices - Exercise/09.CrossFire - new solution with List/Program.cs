namespace _09.CrossFire___new_solution_with_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            var matrix = InitializeMatrix();

            matrix = MarkDestroyMatrixCells(matrix);

            RemoveMarkedCells(matrix);

        }

        static void RemoveMarkedCells(List<List<int>> matrix)
        {
            for (int rowIndex = matrix.Count - 1; rowIndex >= 0; rowIndex--)
            {
                for (int colIndex = matrix[rowIndex].Count - 1; colIndex >= 0; colIndex--)
                {
                    if (matrix[rowIndex][colIndex] == -1)
                    {
                        matrix[rowIndex].RemoveAt(colIndex);
                    }
                }
                if (matrix[rowIndex].Count == 0)
                {
                   matrix.RemoveAt(rowIndex);  
                }
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(List<List<int>> matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
            {
                Console.WriteLine(string.Join(" ", matrix[rowIndex]));
            }
        }

        static List<List<int>> MarkDestroyMatrixCells(List<List<int>> matrix)
        {
            var inputCommands = string.Empty;

            while ((inputCommands = Console.ReadLine()) != "Nuke is from orbit")
            {
                var commands = inputCommands
                    .Split(new char[] {' '},
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var destroyedRow = commands[0];
                var destroyedCol = commands[1];
                var destroyedRadius = commands[2];

                for (int rowIndex = destroyedRow - destroyedRadius; rowIndex <= destroyedRow + destroyedRadius; rowIndex++)
                {
                    if (IsInMatrix(rowIndex, destroyedCol, matrix))
                    {
                        matrix[rowIndex][destroyedCol] = -1;
                    }
                }

                for (int colIndex = destroyedCol - destroyedRadius; colIndex <= destroyedCol + destroyedRadius; colIndex++)
                {
                    if (IsInMatrix(destroyedRow, destroyedCol, matrix))
                    {
                        matrix[destroyedRow][colIndex] = -1;
                    }
                }
            }

            for (int rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
            {
                Console.WriteLine(string.Join(" ", matrix[rowIndex]));
            }
            return matrix;
        }

        static bool IsInMatrix(int currentRow, int currentCol, List<List<int>> matrix)
        {
            if (currentRow >= 0 && currentRow < matrix.Count &&
                currentCol >= 0 && currentCol <matrix[currentRow].Count)
            {
                return true;
            }
            return false;
        }

        static List<List<int>> InitializeMatrix()
        {
            var dimention = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = dimention[0];
            var columns = dimention[1];

            var matrix = new List<List<int>>();

            var filledValue = 1;

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix.Add(new List<int>());
                for (int colIndex = 0; colIndex < columns; colIndex++)
                {
                    matrix[rowIndex].Add(filledValue);
                    filledValue++;
                }
            }

            return matrix;
        }
    }
}
