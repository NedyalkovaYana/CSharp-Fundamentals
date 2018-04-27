using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    private int laps;

    public int Laps
    {
        get { return laps; }
        set { laps = value; }
    }

    public CircuitRace(int length, string route, int prizePool, int laps) 
        : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public override string Performance()
    {
        foreach (var par in Participiants)
        {
            par.Durability -= this.Laps *(this.Length * this.Length);
            par.Performance = (par.Horsepower / par.Acceleration) + (par.Suspension + par.Durability);
        }

        var winners = Participiants.OrderByDescending(p => p.Performance).Take(4).ToList();
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length * Laps}");
        var count = 1;
        var money = new List<int>();
        money.Add((this.PrizePool * 40) / 100);
        money.Add((this.PrizePool * 30) / 100);
        money.Add((this.PrizePool * 20) / 100);
        money.Add((this.PrizePool * 10) / 100);

        foreach (var winCar in winners)
        {

            sb.AppendLine($"{count}. {winCar.Brand} {winCar.Model} {winCar.Performance}PP" +
                          $" - ${money[count - 1]}");
            count++;

        }

        return sb.ToString().Trim();
    }
}

