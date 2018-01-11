using System.Linq;

namespace _03.Squares_in_Matrix
{
    using System;
    using System.Collections.Generic;

    class SquaresInMatrix
    {
        static void Main()
        {
            var inputsCoordinates = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = inputsCoordinates[0];
            var columns = inputsCoordinates[1];

            var matrix = new char[rows][];
            var countSquares = 0;

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }           

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < columns - 1; col++)
                {
                    if (matrix[row][col] == matrix[row][col + 1] && 
                        matrix[row][col] == matrix[row + 1][col] && 
                        matrix[row][col] == matrix[row + 1][col + 1])
                    {
                        countSquares++;
                    }
                }
            }

            Console.WriteLine(countSquares);
        }
    }
}
