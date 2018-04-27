using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class GameController : IGameController
{
    private const string CommandSuffux = "Command";

    private IArmy army;
    private Dictionary<string, List<Ammunition>> wareHouse;
    private MissionController missionControllerField;
    private IWriter writer;
    private IMissionFactory missionFactory;
    private Type[] commands;

    public GameController
        (IWriter writer, 
        ISoldierFactory soldierFactory, 
        IWareHouse wareHouse,
        IArmy army,
        IMissionFactory missionFactory)
    {
        this.SoldierFactory = soldierFactory;
        this.writer = writer;
        this.WareHouse = wareHouse;
        this.Army = army;
        this.MissionFactory = missionFactory;
        this.MissionControllerProp = new MissionController(army, wareHouse);
        this.commands = new TypeCollector().GetAllInheritingTypes<ICommand>();
    }
    public IArmy Army { get; private set; }
    public IWareHouse WareHouse { get; private set; }
    public MissionController MissionControllerProp { get; private set; }
    public IAmmunitionFactory AmunitionFactory { get; private set; }
    public ISoldierFactory SoldierFactory { get; private set; }
    public IMissionFactory MissionFactory { get; private set; }

    public void ProcessCommand(string input)
    {
        var inputData = input.Split().ToList();
        var commandName = inputData[0];

        if (commandName.Equals("Soldier", StringComparison.OrdinalIgnoreCase) &&
            inputData[1].Equals("Regenerate", StringComparison.OrdinalIgnoreCase))
        {
            commandName = "Regenerate";
            inputData = inputData.Skip(2).ToList();
        }
        else
        {
            inputData = inputData.Skip(1).ToList();
        }

        try
        {
            var commandType = this.commands
                .FirstOrDefault(c => c.Name.Equals(commandName + CommandSuffux));

            var commandInstance = (ICommand) Activator.CreateInstance(commandType, inputData, this);
            commandInstance.Execute();
        }
        catch (TargetInvocationException tie)
        {
            throw tie.InnerException;
        }
    }

    public void RegenerateSoldiers(string soldiersType)
    {
      this.Army.RegenerateTeam(soldiersType);
    }

    public void ProduceSummary()
    {
        this.MissionControllerProp.FailMissionsOnHold();

        writer.StoreMessages(OutputMessages.Results);
        writer.StoreMessages(String.Format(OutputMessages.SuccessfullMissions, this.MissionControllerProp.SuccessMissionCounter));
        writer.StoreMessages(String.Format(OutputMessages.FiledMissions, this.MissionControllerProp.FailedMissionCounter));
        writer.StoreMessages(OutputMessages.Soldiers);

        foreach (var soldier in Army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            writer.StoreMessages(String.Format
                (OutputMessages.SoldierToString, soldier.Name, soldier.OverallSkill));
        }
    }
}
