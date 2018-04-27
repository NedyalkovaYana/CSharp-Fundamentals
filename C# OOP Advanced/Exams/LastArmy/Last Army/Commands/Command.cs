
using System.Collections.Generic;

public abstract class Command : ICommand
{
    protected Command(IList<string> cmdArgs, IGameController gameController)
    {
        this.CmdArgs = cmdArgs;
        this.GameController = gameController;
    }

    protected IList<string> CmdArgs { get; private set; }
    protected IGameController GameController { get; private set; }
    public abstract void Execute();

}

