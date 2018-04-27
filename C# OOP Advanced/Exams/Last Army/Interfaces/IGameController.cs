public interface IGameController
{
    IArmy Army { get; }
    IWareHouse WareHouse { get; }

    MissionController MissionControllerProp { get; }
    IAmmunitionFactory AmmunitionFactory { get; }
    ISoldierFactory SoldierFactory { get; }
    IMissionFactory MissionFactory { get; }
    void GiveInputToGameController(string input);
    void RegenerateSoldiers(string soldiersType);
}

