using System;
using System.Linq;

public class Smartphone : ISmartphonable
{
    public string Model { get; private set; }

    public Smartphone(string model)
    {
        this.Model = model;
    }
    public string Call(string number)
    {
        if (!number.Any(Char.IsDigit))
        {
            return "Invalid number!";
        }
        return $"Calling... {number}";
    }

    public string Browse(string url)
    {
        if (url.Any(Char.IsDigit))
        {
            return "Invalid URL!";
        }

        return $"Browsing: {url}!";
    }
}

