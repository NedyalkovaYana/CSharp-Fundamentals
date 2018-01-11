namespace _04.PascalTriangle
{
    using System;
    using System.Collections.Generic;
    class PascalTriangle
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] triangle = new int[n][];

            for (int row = 0; row < n; row++)
            {
                triangle[row] = new int[row + 1];

            }
            triangle[0][0] = 1;
            for (int row = 0; row < n - 1; row++)
            {
                for (int col = 0; col <= row ; col++)
                {
                    triangle[row + 1][col] += triangle[row][col];
                    triangle[row + 1][col + 1] += triangle[row][col];
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    Console.Write("{0,1} ", triangle[row][col]);
                }
                Console.WriteLine();
            }

        }
    }
}
