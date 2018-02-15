namespace Cubics_Rube
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            int dimention = int.Parse(Console.ReadLine());
            var sumOfParticles = 0L;
            var counterChangedCells = 0;
            var inputLine = string.Empty;
            while ((inputLine = Console.ReadLine()) != "Analyze")
            {
                var tokens = inputLine
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (tokens.Take(3).Any(pt => pt < 0 || pt >= dimention))
                {
                    continue;
                }

                if (tokens[3] != 0)
                {
                    sumOfParticles += tokens[3];
                    counterChangedCells++;
                }     
            }

            Console.WriteLine(sumOfParticles);
            Console.WriteLine(Math.Pow(dimention, 3) - counterChangedCells);
        }
    }
}
