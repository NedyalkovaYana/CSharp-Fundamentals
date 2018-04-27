
public class SolarProvider : Provider
{
    private const int IncreasesDurability = 500;
    public SolarProvider(int id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.Durability += 500;
    }
}

