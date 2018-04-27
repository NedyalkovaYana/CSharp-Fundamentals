
using System.Collections.Generic;

public class RegisterCommand : Command
{
    public RegisterCommand(IList<string> arguments, ICommandInterpreter interpreter)
        : base(arguments, interpreter)
    {
    }

    public override string Execute()
    {
        if (Arguments[0] == "Harvester")
        {
           return Interpreter.HarvesterController.Register(Arguments);
        }
        else
        {
           return Interpreter.ProviderController.Register(Arguments);
        }
    }
}

