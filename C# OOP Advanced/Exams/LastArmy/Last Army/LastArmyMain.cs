using System;
using System.Text;

public class LastArmyMain
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        ISoldierFactory soldierFactory = new SoldierFactory();
        IWareHouse wareHouse = new Warehouse();
        IArmy army = new Army();
        IMissionFactory missionFactory = new MissionFactory();
        IGameController gameController = new GameController
            (writer, soldierFactory, wareHouse, army, missionFactory);

        var engine = new Engine(reader, writer, gameController);
        engine.Run();

    }
}
