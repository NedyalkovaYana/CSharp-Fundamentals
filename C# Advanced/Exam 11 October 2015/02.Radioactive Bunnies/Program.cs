using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace _02.Radioactive_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = InitializeMatrix();
            PlayTheGame(matrix);
        }

        private static void PlayTheGame(char[][] matrix)
        {
            var isAlive = true;
            var isEscape = false;
            var holdFinalPlayerSteps = new List<int>();
            var playerMove = Console.ReadLine().ToLower().ToCharArray();

            while (isAlive && isEscape == false)
            {
                for (int i = 0; i < playerMove.Length; i++)
                {
                    var move = playerMove[i];
                    PlayerMove(move, matrix, isAlive, isEscape, holdFinalPlayerSteps);
                    BunnyMoves(matrix, isAlive, isEscape);
                    if (isAlive == false)
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"dead: {holdFinalPlayerSteps[0]} {holdFinalPlayerSteps[1]}");
                        break;
                    }
                    if (isEscape == true)
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"won: {holdFinalPlayerSteps[0]} {holdFinalPlayerSteps[1]}");
                        break;
                    }                  
                }
            }
        }

        static void PrintMatrix(char[][] matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                Console.WriteLine(string.Join(" ", matrix[rowIndex]));
            }
        }

        static void BunnyMoves(char[][] matrix, bool isAlive, bool isEscape)
        {
            
            for (int row = 0; row < matrix.Length; row++)
            {
               
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B') //?
                    {
                        //go down
                        row++;
                        AddNewBunnys(matrix, row, col, isAlive, isEscape);

                        // go up
                        row -= 2;
                        AddNewBunnys(matrix, row, col, isAlive, isEscape);
                        //go left
                        row++;
                        col--;
                        AddNewBunnys(matrix, row, col, isAlive, isEscape);

                        //go right
                        col += 2;
                        AddNewBunnys(matrix, row, col, isAlive, isEscape);

                        if (isAlive == false)
                        {
                            return;
                        }
                    }

                }
            }
        }

        static void AddNewBunnys(char[][] matrix, int row, int col, bool isAlive, bool isEscape)
        {
            if (IsInMatrix(matrix, row, col))
            {
                if (matrix[row][col] == '.')
                {
                    matrix[row][col] = 'B';
                }
                else if (matrix[row][col] == 'P')
                {
                    matrix[row][col] = 'B';
                    isAlive = false;
                }
                
            }

        }

        static void PlayerMove(char move, char[][] matrix, bool isAlive, bool isEscape, List<int> finalSteps)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'P') //P??
                    {
                        matrix[row][col] = '.';
                        switch (move)
                        {
                            case 'l':
                                col--;
                                if (IsInMatrix(matrix, row, col))
                                {
                                    if (matrix[row][col] == '.')
                                    {
                                        matrix[row][col] = 'P';
                                        break;
                                    }
                                    else
                                    {
                                        isAlive = false;
                                        finalSteps.Add(row);
                                        finalSteps.Add(col);
                                        return;
                                    }
                                }
                                else
                                {
                                    isEscape = true;
                                    finalSteps.Add(row);
                                    finalSteps.Add(col);
                                    return;
                                }
                               
                                break;
                            case 'r':
                                col += 2;
                                if (IsInMatrix(matrix, row, col))
                                {
                                    if (matrix[row][col] == '.')
                                    {
                                        matrix[row][col] = 'P';
                                    }
                                    else
                                    {
                                        isAlive = false;
                                        finalSteps.Add(row);
                                        finalSteps.Add(col);
                                        return;
                                    }
                                }
                                else
                                {
                                    isEscape = true;
                                    finalSteps.Add(row);
                                    finalSteps.Add(col);
                                    return;
                                }
                                break;
                            case 'u':
                                col--;
                                row--;

                                if (IsInMatrix(matrix, row, col))
                                {
                                    if (matrix[row][col] == '.')
                                    {
                                        matrix[row][col] = 'P';
                                    }
                                    else
                                    {
                                        isAlive = false;
                                        finalSteps.Add(row);
                                        finalSteps.Add(col);
                                        return;
                                    }
                                }
                                else
                                {
                                    isEscape = true;
                                    finalSteps.Add(row);
                                    finalSteps.Add(col);
                                    return;
                                }
                                break;
                            case 'd':
                                row++;
                                if (IsInMatrix(matrix, row, col))
                                {
                                    if (matrix[row][col] == '.')
                                    {
                                        matrix[row][col] = 'P';
                                    }
                                    else
                                    {
                                        isAlive = false;
                                        finalSteps.Add(row);
                                        finalSteps.Add(col);
                                        return;
                                    }
                                }
                                else
                                {
                                    isEscape = true;
                                    finalSteps.Add(row);
                                    finalSteps.Add(col);
                                    return;
                                }
                                break;
                        }
                    }
                }
            }
        }

        static bool IsInMatrix(char[][] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }

        private static char[][] InitializeMatrix()
        {
            var dimentions = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimentions[0];
            
            var matrix = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }
            return matrix;
        }
    }
}
