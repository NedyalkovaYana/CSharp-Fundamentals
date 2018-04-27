
public class Medium : Mission
{
    private const string MissionName = "Capturing dangerous criminals";
    private const double CurrentEnduranceRequired = 50;
    private const int WearLevelDecrementForEachWeapon = 50;
    public Medium(double scoreToComplete) 
        : base(MissionName, CurrentEnduranceRequired, scoreToComplete, 
            WearLevelDecrementForEachWeapon)
    {
    }
}

