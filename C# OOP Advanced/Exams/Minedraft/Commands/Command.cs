
using System.Collections.Generic;

public abstract class Command : ICommand
{
    protected Command(IList<string> arguments, ICommandInterpreter interpreter)
    {
        this.Arguments = arguments;
        this.Interpreter = interpreter;
    }

    public IList<string> Arguments { get; }
    protected ICommandInterpreter Interpreter { get; }

    public abstract string Execute();
}

