namespace _03.Periodic_Table
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PeriodicTable
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var uniqueChemicalCompounds = new HashSet<string>();
          

            for (int i = 0; i < n; i++)
            {
                Console.ReadLine()
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList()                  
                    .ForEach(compounds => uniqueChemicalCompounds.Add(compounds));
            }

            foreach (var element in uniqueChemicalCompounds.OrderBy(a => a))
            {
                Console.Write(element + " ");
            }
        }
    }
}
