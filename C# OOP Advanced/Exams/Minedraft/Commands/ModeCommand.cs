
using System;
using System.Collections.Generic;

public class ModeCommand : Command
{
  
    public ModeCommand(IList<string> arguments, ICommandInterpreter interpreter) 
        : base(arguments, interpreter)
    {

    }
    public override string Execute()
    { 
        //Possible bugy
        var currentMode = Arguments[0];

       return Interpreter.HarvesterController.ChangeMode(currentMode);
    }
}
