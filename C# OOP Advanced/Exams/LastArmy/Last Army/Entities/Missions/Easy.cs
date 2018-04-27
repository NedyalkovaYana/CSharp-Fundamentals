
public class Easy : Mission
{
    private const double ConstEnduranceRequired = 20;
    private const int ConstWearLevelDecreasment = 30;
    private const string MissionName = "Suppression of civil rebellion";
    public Easy(double scoreToComplete) 
        : base(MissionName, ConstEnduranceRequired, scoreToComplete)
    {
        this.WearLevelDecrement = ConstWearLevelDecreasment;
    }

    public override double WearLevelDecrement { get; }
}

