
public class Medium : Mission
{
    private const string MissionName = "Capturing dangerous criminals";
    private const int ConstWearLevelDecreasment = 50;
    private const double ConstEnduranceRequired = 50;
    public Medium(double scoreToComplete)
        : base(MissionName, ConstEnduranceRequired, scoreToComplete)
    {
        this.WearLevelDecrement = ConstWearLevelDecreasment;
    }

    public override double WearLevelDecrement { get; }
}

