using System;
using System.Text;

public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;
    private const int DurabilityDailyLoss = 100;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;       
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; }
    public double Durability { get; set; }
    public double EnergyOutput { get; protected set; }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Broke()
    {
        this.Durability -= DurabilityDailyLoss;
    }
    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(this.GetType().Name)
          .AppendLine($"Durability: {this.Durability}");

        return sb.ToString().Trim();
    }
}