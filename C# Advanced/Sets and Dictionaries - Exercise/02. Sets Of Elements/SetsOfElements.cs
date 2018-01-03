namespace _02.Sets_Of_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SetsOfElements
    {
        static void Main()
        {
            var lengths = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var nLength = lengths[0];
            var mLength = lengths[1];

            var nCollection = new SortedSet<int>();
            var mCollection = new SortedSet<int>();

            for (int i = 0; i < nLength + mLength; i++)
            {
                if (i < nLength)
                {
                    nCollection.Add(int.Parse(Console.ReadLine()));
                }
                else
                {
                    mCollection.Add(int.Parse(Console.ReadLine()));
                }
            }

            foreach (var element in nCollection)
            {
                if (mCollection.Contains(element))
                {
                    Console.Write(element + " ");
                }
            }
            Console.WriteLine();

        }
    }
}
