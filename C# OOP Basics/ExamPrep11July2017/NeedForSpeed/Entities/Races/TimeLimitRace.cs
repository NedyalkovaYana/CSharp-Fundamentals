using System.Text;

public class TimeLimitRace : Race
{
    private int goldTime;

    public int GoldTime
    {
        get { return goldTime; }
        protected set { goldTime = value; }
    }

    public TimeLimitRace(int length, string route, int prizePool, int goldTime) 
        : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public void AddPartisipant(Car car)
    {
        if (Participiants.Count < 1)
        {
            this.Participiants.Add(car);
        }
    }

    public override string Performance()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");
        foreach (var car in Participiants)
        {
            car.Performance = this.Length * ((car.Horsepower / 100) * car.Acceleration);
            sb.AppendLine($"{car.Brand} {car.Model} - {car.Performance} s.");
            if (this.GoldTime >= car.Performance)
            {
                sb.AppendLine($"Gold Time, ${this.PrizePool}.");
            }
            else if (car.Performance <= this.GoldTime + 15)
            {
                sb.AppendLine($"Silver Time, ${this.PrizePool / 2}.");
            }
            else if (car.Performance > this.GoldTime + 15)
            {
                sb.AppendLine($"Bronze Time, ${this.PrizePool - ((this.PrizePool * 30)/100)}.");
            }
        }

        return sb.ToString().Trim();
    }
}

