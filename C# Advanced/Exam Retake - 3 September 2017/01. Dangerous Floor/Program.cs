using System.Text.RegularExpressions;

namespace _01.Dangerous_Floor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            var rows = 8;
            var cols = 8;
            var matrix = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            var moves = string.Empty;
            while ((moves = Console.ReadLine()) != "END")
            {
                var tokens = moves.ToCharArray();
                var figure = tokens[0];
                var startRow = int.Parse(tokens[1].ToString());
                var startCol = int.Parse(tokens[2].ToString());
                var endRow = int.Parse(tokens[4].ToString());
                var endCol = int.Parse(tokens[5].ToString());

                if (matrix[startRow][startCol] != figure)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
                else
                {
                    switch (figure)
                    {
                        case 'K':
                            var squaresRow = Math.Abs(endRow - startRow);
                            var squaresCol = Math.Abs(endCol - startCol);
                            if ( squaresRow > 1 || squaresCol > 1)
                            {
                                Console.WriteLine($"Invalid move!");
                                continue;
                            }
                            else if (!IsInMatrix(matrix, rows, cols, endRow, endCol))
                            {
                                Console.WriteLine("Move go out of board!");
                                continue;
                            }
                            else
                            {
                                matrix[startRow][startCol] = 'x';
                                matrix[endRow][endCol] = figure;
                            }
                            break;
                        case 'R':
                            if (startCol == endCol || startRow == endRow)
                            {
                                if (!IsInMatrix(matrix, rows, cols, endRow, endCol))
                                {
                                    Console.WriteLine("Move go out of board!");
                                    continue;
                                }
                                matrix[startRow][startCol] = 'x';
                                matrix[endRow][endCol] = figure;
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                        case 'B':
                            if (startCol != endCol && startRow != endRow)
                            {
                                if (!IsInMatrix(matrix, rows, cols, endRow, endCol))
                                {
                                    Console.WriteLine("Move go out of board!");
                                    continue;
                                }
                                matrix[startRow][startCol] = 'x';
                                matrix[endRow][endCol] = figure;
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                        case 'Q':
                            if (!IsInMatrix(matrix, rows, cols, endRow, endCol))
                            {
                                Console.WriteLine("Move go out of board!");
                                continue;
                            }
                            matrix[startRow][startCol] = 'x';
                            matrix[endRow][endCol] = figure;
                            break;
                        case 'P':
                            if (startRow - endRow == 1 && startCol == endCol)
                            {
                                if (!IsInMatrix(matrix, rows, cols, endRow, endCol))
                                {
                                    Console.WriteLine("Move go out of board!");
                                    continue;
                                }
                                matrix[startRow][startCol] = 'x';
                                matrix[endRow][endCol] = figure;
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                    }
                }

            }
        }

        static bool IsInMatrix(char[][] matrix, int rows, int cols, int endRow, int endCol)
        {
            return endRow >= 0 && endCol >= 0 && endRow < matrix.Length && endCol < matrix[endRow].Length; //??
        }
    }
}
