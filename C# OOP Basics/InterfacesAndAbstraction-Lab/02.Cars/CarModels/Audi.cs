using System;
using System.Text;

public class Audi : ICar
{
    public string Model { get; private set; }
    public string Color { get; private set; }

    public Audi(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }
    public string Start()
    {
        return $"Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}")
            .AppendLine($"{this.Start()}")
            .AppendLine($"{this.Stop()}");

        return sb.ToString().Trim();
    }
}

