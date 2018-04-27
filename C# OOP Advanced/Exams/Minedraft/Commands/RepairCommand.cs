using System;
using System.Collections.Generic;

public class RepairCommand : Command
{
    public RepairCommand(IList<string> arguments, ICommandInterpreter interpreter) 
        : base(arguments, interpreter)
    {
    }

    public override string Execute()
    {
        return Interpreter.ProviderController.Repair(double.Parse(Arguments[0]));
    }
}

