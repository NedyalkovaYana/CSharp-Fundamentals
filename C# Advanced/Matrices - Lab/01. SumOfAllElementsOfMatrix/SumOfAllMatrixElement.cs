namespace _01.SumOfAllElementsOfMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class SumOfAllMatrixElement
    {
        static void Main()
        {
            var inputRowsCollsCount = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = inputRowsCollsCount[0];
            var cols = inputRowsCollsCount[1];

            var matrix = new int[rows][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Take(cols)
                    .ToArray();

            }

            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[0].Length);
            Console.WriteLine(matrix.Select(row => row.Sum()).Sum());
        }
    }
}
