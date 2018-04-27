
public class Hard : Mission
{
    private const string MissionName = "Disposal of terrorists";
    private const double CurrentEnduranceRequired = 80;
    private const int WearLevelDecrementForEachWeapon = 70;
    public Hard(double scoreToComplete) 
        : base(MissionName, CurrentEnduranceRequired, scoreToComplete,
            WearLevelDecrementForEachWeapon)
    {
    }
}

