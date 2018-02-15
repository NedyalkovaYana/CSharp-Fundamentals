using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var rectanglesCoordinate = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();
        var topLeftX = rectanglesCoordinate[0];
        var topLeftY = rectanglesCoordinate[1];
        var bottomRightX = rectanglesCoordinate[2];
        var bottomRightY = rectanglesCoordinate[3];

        var rectangle = new Rectangle(topLeftX, topLeftY, bottomRightX, bottomRightY);

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var currentPoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var x = currentPoints[0];
            var y = currentPoints[1];

            var point = new Point(x, y);
            Console.WriteLine(rectangle.Contains(point));
        }
    }
}

