using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override string Performance()
    {
        foreach (var par in Participiants)
        {
            par.Performance = (par.Horsepower / par.Acceleration) + (par.Suspension + par.Durability);
        }

        var winners = Participiants.OrderByDescending(p => p.Performance).Take(3).ToList();
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");
        var count = 1;
        var money = new List<int>();
        money.Add((this.PrizePool * 50) / 100);
        money.Add((this.PrizePool * 30) / 100);
        money.Add((this.PrizePool * 20) / 100);

        foreach (var winCar in winners)
        {

            sb.AppendLine($"{count}. {winCar.Brand} {winCar.Model} {winCar.Performance}PP" +
                          $" - ${money[count-1]}");
            count++;

        }
       
        return sb.ToString().Trim();
    }
}

