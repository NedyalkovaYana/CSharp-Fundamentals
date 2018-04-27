using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    public ShutdownCommand(IList<string> arguments, ICommandInterpreter interpreter) 
        : base(arguments, interpreter)
    {
    }

    public override string Execute()
    {
        var totalEnergyProdused = Interpreter.ProviderController.TotalEnergyProduced;
        var totalMinedOre = Interpreter.HarvesterController.OreProduced;

        var sb = new StringBuilder();

        sb.AppendLine("System Shutdown")
            .AppendLine($"Total Energy Produced: {totalEnergyProdused}")
            .AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");

        return sb.ToString().Trim();
    }
}

