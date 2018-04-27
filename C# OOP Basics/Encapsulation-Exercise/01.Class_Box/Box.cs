using System;
using System.Net.Http.Headers;

public class Box
{
    //length, width and height
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }
    public double Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException
                    ($"{nameof(Height)} cannot be zero or negative.");
            }
            height = value;
        }
    }


    public double Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException
                    ($"{nameof(Width)} cannot be zero or negative.");
            }
            width = value;
        }
    }


    public double Length
    {
        get { return length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException
                    ($"{nameof(Length)} cannot be zero or negative.");
            }
            length = value;
        }
    }

    public double SurfaceArea()
    {
        return  2 * this.Length * this.Width 
                        + 2 * this.Length * this.Height
                        + 2 * this.Width * this.Height;
        
    }

    public double LateralSurfaceArea()
    {
        var lateralArea = 2 * this.Length * this.Height
                        + 2 * this.Width * this.Height;
        return lateralArea;
    }

    public double Volume()
    {
        var volume = this.Height * this.Width * this.Length;
        return volume;
    }

}
