
public class PressureProvider : Provider
{
    private const int DecreasesDurability = 300;
    private const int EnergyOutputMultiplayer = 2;
    public PressureProvider(int id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.Durability -= DecreasesDurability;
        this.EnergyOutput *= EnergyOutputMultiplayer;
    }
}

