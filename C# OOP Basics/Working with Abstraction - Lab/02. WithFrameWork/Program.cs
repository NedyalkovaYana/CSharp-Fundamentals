using System;
using System.Linq;

public class Program
{
    public class Point
    {
        private int x;
        private int y;

        public int X => this.x;
        public int Y => this.y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
    public class Rectangle
    {
        private int topLeftX;
        private int toplLeftY;
        private int bottomRightX;
        private int bottomRightY;

        public int TopLeftX => this.topLeftX;
        public int TopLeftY => this.toplLeftY;
        public int BottomRightX => this.bottomRightX;
        public int BottomRightY => this.bottomRightY;

        public Rectangle(int topLeftX, int toplLeftY, int bottomRightX, int bottomRightY)
        {
            this.topLeftX = topLeftX;
            this.toplLeftY = toplLeftY;
            this.bottomRightX = bottomRightX;
            this.bottomRightY = bottomRightY;
        }

        public bool Contains(Point point)
        {
            //“<topLeftX> <topLeftY> <bottomRightX> <bottomRightY>
            if (this.topLeftX <= point.X && point.X <= this.bottomRightX)
            {
                if (this.toplLeftY <= point.Y && point.Y <= this.bottomRightY)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public static void Main(string[] args)
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

