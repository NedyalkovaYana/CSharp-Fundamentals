using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

public class SartUp
{
    public static void Main()
    {
        var rectangularList = new List<Rectangle>();
        var inputInfo = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        var numbersOfRectangular = inputInfo[0];
        var intersectionCecks = inputInfo[1];
      
        for (int i = 0; i < numbersOfRectangular; i++)
        {
            var coordinates = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var id = coordinates[0];
            var width = double.Parse(coordinates[1]);
            var height = double.Parse(coordinates[2]);
            var horizontalPoint = double.Parse(coordinates[3]);
            var verticalPoint = double.Parse(coordinates[4]);

            var currentRectangle = new Rectangle(id, width, height, horizontalPoint, verticalPoint);

            rectangularList.Add(currentRectangle);
        }

        for (int i = 0; i < intersectionCecks; i++)
        {
            var ids = Console.ReadLine().Split();

            var firstRectangle = rectangularList.Where(f => f.Id == ids[0]).FirstOrDefault();
            var secondRectangle = rectangularList.Where(s => s.Id == ids[1]).FirstOrDefault();

            Console.WriteLine(firstRectangle.Intersect(secondRectangle)? "true" : "false");
        }
    }
}

