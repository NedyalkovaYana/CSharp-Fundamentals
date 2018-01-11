using System.Linq;

namespace _01.Matrix_of_Palindromes
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var inputMatrixParameters = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = inputMatrixParameters[0];
            var columns = inputMatrixParameters[1];

            string[,] matrix = new string[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var middleLetter = alphabet[row + col];
                    var currentWord = alphabet[row] + middleLetter.ToString() + alphabet[row];
                        matrix[row, col] = currentWord;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
