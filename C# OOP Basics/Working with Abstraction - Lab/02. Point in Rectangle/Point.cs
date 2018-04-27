using System.Security.Cryptography.X509Certificates;

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

