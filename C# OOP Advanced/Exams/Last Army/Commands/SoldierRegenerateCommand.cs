
using System.Collections.Generic;

class SoldierRegenerateCommand : Command
{
    public SoldierRegenerateCommand(IList<string> cmdArgs, IGameController gameController) 
        : base(cmdArgs, gameController)
    {
    }

    public override void Execute()
    {
        var soldierType = this.CmdArgs[0];
        this.GameController.RegenerateSoldiers(soldierType);
    }
}
