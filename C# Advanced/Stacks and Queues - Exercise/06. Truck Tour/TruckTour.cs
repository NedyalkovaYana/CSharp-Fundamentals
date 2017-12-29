namespace _06.Truck_Tour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TruckTour
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                 pumps.Enqueue(Console.ReadLine()
                     .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray());
            }

            var truckFuel = 0;
            var startIndex = 0;
            var loopBotton = pumps.Count;

            for (int i = 0; i <= loopBotton && startIndex < pumps.Count; i++)
            {
                var currentPump = pumps.Dequeue();
                pumps.Enqueue(currentPump);
                truckFuel += currentPump[0] - currentPump[1];

                if (truckFuel < 0)
                {
                    startIndex = i + 1;
                    loopBotton += pumps.Count;
                    truckFuel = 0;
                }
            }

            Console.WriteLine(startIndex);
        }
    }
}
