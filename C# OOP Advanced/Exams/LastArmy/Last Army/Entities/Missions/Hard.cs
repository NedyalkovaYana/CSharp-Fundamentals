
public class Hard : Mission
{
    private const string MissionName = "Disposal of terrorists";
    private const double ConstEnduranceRequired = 80;
    private const int ConstWearLevelDecreasment = 70;
    public Hard(double scoreToComplete)
        : base(MissionName, ConstEnduranceRequired, scoreToComplete)
    {
        this.WearLevelDecrement = ConstWearLevelDecreasment;
    }

    public override double WearLevelDecrement { get; }
}

