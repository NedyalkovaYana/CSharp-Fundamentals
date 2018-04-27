public interface IGameController
{
    IArmy Army { get; }

    IWareHouse WareHouse { get; }

    MissionController MissionControllerProp { get; }

    IAmmunitionFactory AmunitionFactory { get; }

    ISoldierFactory SoldierFactory { get; }

    IMissionFactory MissionFactory { get; }

    void ProcessCommand(string input);

    void RegenerateSoldiers(string soldiersType);
    void ProduceSummary();
}

