public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput, energyRequirement/sonicFactor)
    {
        this.SonicFactor = sonicFactor;
    }

    public int SonicFactor
    {
        get { return this.sonicFactor; }
        protected set { this.sonicFactor = value; }
    }

    //UPON INITIALIZATION, divides its given energyRequirement by its sonicFactor.
}

