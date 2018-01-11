namespace _7.Lego_Blocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LegoBlocks
    {
        static void Main()
        {
            int arraysRows = int.Parse(Console.ReadLine());

            var firstJaggedArray = ReadInputs(arraysRows);
            var secondJaggedArray = ReadInputs(arraysRows);

            ReverseSecondJaggedArray(secondJaggedArray, arraysRows);
            PrintResult(firstJaggedArray, secondJaggedArray);
           
        }

        static void PrintResult(int[][] firstJaggedArray, int[][] secondJaggedArray)
        {
            if (IsRectangularMatrix(firstJaggedArray, secondJaggedArray))
            {
                for (int i = 0; i < firstJaggedArray.Length; i++)
                {
                    Console.WriteLine
                        ($"[{string.Join(", ", firstJaggedArray[i].Concat(secondJaggedArray[i]))}]");
                }
            }
            else
            {
                Console.WriteLine
                    ($"The total number of cells is: {CellsCount(firstJaggedArray, secondJaggedArray)}");
            }
        }

        static object CellsCount(int[][] firstJaggedArray, int[][] secondJaggedArray)
        {
            var numberOfCells = 0;

            for (int i = 0; i < firstJaggedArray.Length; i++)
            {
                numberOfCells += firstJaggedArray[i].Length + secondJaggedArray[i].Length;
            }
            return numberOfCells;
        }

        static bool IsRectangularMatrix(int[][] firstJaggedArray, int[][] secondJaggedArray)
        { 
            for (int i = 1; i < firstJaggedArray.Length; i++)
            {
                if (firstJaggedArray[i].Length + secondJaggedArray[i].Length != 
                    firstJaggedArray[i - 1].Length + secondJaggedArray[i - 1].Length)
                {
                    return false;
                }
            }
            return true;
        }


        static void ReverseSecondJaggedArray(int[][] secondJaggedArray, int arr)
        {
            for (int i = 0; i < arr; i++)
            {
                Array.Reverse(secondJaggedArray[i]);
            }
        }

        static int[][] ReadInputs(int arraysRows)
        {
            var matrix = new int[arraysRows][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            return matrix;
        }
    }

}

        
    
