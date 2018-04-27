
using System;
using System.Collections.Generic;
using System.Linq;

public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandSuffix = "Command";
    private Type[] commands;

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public CommandInterpreter(IHarvesterController harvesterController,
                               IProviderController providerController)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
        this.commands = new TypeCollector().GetAllInheritingTypes<ICommand>();
    }

    public IReadOnlyCollection<IEntity> Entities;
    public IHarvesterController HarvesterController => this.harvesterController;
    public IProviderController ProviderController => this.providerController;

    public string ProcessCommand(IList<string> args)
    {
        var commandName = args[0] + CommandSuffix;
        args = args.Skip(1).ToList();

        var commandType = this.commands
            .FirstOrDefault(c => c.Name.Equals(commandName));

        var commandInstance = (ICommand)Activator.CreateInstance(commandType, args, this);
        return commandInstance.Execute();
    }
}

