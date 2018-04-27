
using System.Collections.Generic;

public class WarehouseCommand : Command
{
    public WarehouseCommand(IList<string> cmdArgs, IGameController gameController)
        : base(cmdArgs, gameController)
    {
    }

    public override void Execute()
    {
        var name = this.CmdArgs[0];
        var count = int.Parse(this.CmdArgs[1]);

        this.GameController.WareHouse.AddAmmunitions(name, count);
    }
}

