
public class Easy : Mission
{
    private const string MissionName = "Suppression of civil rebellion";
    private const double CurrentEnduranceRequired = 20;
    private const int WearLevelDecrementForEachWeapon = 30;

    public Easy(double scoreToComplete)
        : base(MissionName, CurrentEnduranceRequired, scoreToComplete, 
            WearLevelDecrementForEachWeapon)
    {
    }
}

