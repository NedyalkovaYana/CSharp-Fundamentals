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
        if (this.topLeftX <= point.X  && point.X <= this.bottomRightX)
        {
            if (this.toplLeftY <= point.Y && point.Y <= this.bottomRightY)
            {
                return true;
            }
        }
        return false;
    }
}

