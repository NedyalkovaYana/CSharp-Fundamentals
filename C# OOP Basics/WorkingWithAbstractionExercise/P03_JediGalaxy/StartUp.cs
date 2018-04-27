using System;
using System.Linq;
using System.Numerics;

namespace P03_JediGalaxy
{
    class StartUp
    {
        static void Main()
        {
            int[,] matrix = InitializaMatrix();

            string command = Console.ReadLine();
            BigInteger sum = 0;
            GatheringStars(matrix, ref command, ref sum);
            PrintIvoStars(sum);

        }

        private static void PrintIvoStars(BigInteger sum)
        {
            Console.WriteLine(sum);
        }

        private static void GatheringStars(int[,] matrix, ref string command, ref BigInteger sum)
        {
            while (command != "Let the Force be with you")
            {
                EvilsMove(matrix);
                sum = IvosMove(matrix, command, sum);

                command = Console.ReadLine();
            }
        }

        private static BigInteger IvosMove(int[,] matrix, string command, BigInteger sum)
        {
            int[] ivoS = command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int xI = ivoS[0];
            int yI = ivoS[1];

            while (xI >= 0 && yI < matrix.GetLength(1))
            {
                if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
                {
                    sum += matrix[xI, yI];
                }

                yI++;
                xI--;
            }

            return sum;
        }

        private static void EvilsMove(int[,] matrix)
        {
            int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int xE = evil[0];
            int yE = evil[1];

            while (xE >= 0 && yE >= 0)
            {
                if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
                {
                    matrix[xE, yE] = 0;
                }
                xE--;
                yE--;
            }
        }

        private static int[,] InitializaMatrix()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            return matrix;
        }
    }
}
