using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Command : ICommand
{
    protected Command(IList<string> cmdArgs, IGameController gameController)
    {
        this.CmdArgs = cmdArgs;
        this.GameController = gameController;
    }

    protected IList<string> CmdArgs { get; }
    protected IGameController GameController { get; }
    public abstract void Execute();

}

