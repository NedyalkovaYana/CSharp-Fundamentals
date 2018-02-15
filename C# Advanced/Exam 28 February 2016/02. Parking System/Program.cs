using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _02.Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrixRows = dimentions[0];
            var matrixCols = dimentions[1];

            var matrix = new int[matrixRows][];
            for (int row = 0; row < matrixRows; row++)
            {
                matrix[row] = new int[matrixCols];
            }

            var inputs = string.Empty;
            while ((inputs = Console.ReadLine()).ToLower() != "stop")
            {
                var tokens = inputs
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var entryRow = tokens[0];
                var parkingRow = tokens[1];
                var parkingCol = tokens[2];
                var counterMoves = 1L;
                bool isParking = false;

                if (entryRow != parkingRow)
                {
                    if (entryRow < parkingRow)
                    {
                        while (entryRow < parkingRow)
                        {
                            entryRow++;
                            counterMoves++;
                        }

                    }
                    else if (entryRow > parkingRow)
                    {
                        while (entryRow > parkingRow)
                        {
                            entryRow--;
                            counterMoves++;
                        }
                    }
                }
                if (matrix[parkingRow][parkingCol] == 0)
                {
                    matrix[parkingRow][parkingCol] = 1;
                    counterMoves += parkingCol;
                    isParking = true;
                }

                if (isParking == false)
                {
                    for (int col = parkingCol; col >= 1; col--)
                    {

                        if (matrix[parkingRow][col] == 0)
                        {
                            matrix[parkingRow][col] = 1;
                            counterMoves += col; 
                            
                            isParking = true;
                            break;
                        }

                    }
                }
                if (isParking == false)
                {
                    for (int col = parkingCol + 1; col < matrix[parkingRow].Length; col++)
                    {

                        if (matrix[parkingRow][col] == 0)
                        {
                            matrix[parkingRow][col] = 1;
                            counterMoves += col; 

                            isParking = true;
                            break;
                        }

                    }
                }

                if (isParking)
                {
                    Console.WriteLine(counterMoves);
                    counterMoves = 0;
                }
                else
                {
                    Console.WriteLine($"Row {parkingRow} full");
                    counterMoves = 0;
                }
            }

        }
    }
}
