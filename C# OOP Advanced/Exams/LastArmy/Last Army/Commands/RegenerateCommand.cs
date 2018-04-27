
using System.Collections.Generic;

public class RegenerateCommand : Command
{
    public RegenerateCommand(IList<string> cmdArgs, IGameController gameController) 
        : base(cmdArgs, gameController)
    {
    }

    public override void Execute()
    {
        var soldierType = this.CmdArgs[0];
        this.GameController.RegenerateSoldiers(soldierType);
    }
}

