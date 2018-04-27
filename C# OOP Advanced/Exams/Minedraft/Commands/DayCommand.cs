
using System.Collections.Generic;
using System.Text;

public class DayCommand : Command
{
    public DayCommand(IList<string> arguments, ICommandInterpreter interpreter) 
        : base(arguments, interpreter)
    {
    }

    public override string Execute()
    {
        var sb = new StringBuilder();
        var produseEnergyMessage = Interpreter.ProviderController.Produce();

        var enoughtEnergyToHarvestersMessage = Interpreter.HarvesterController.Produce();

        sb.AppendLine(produseEnergyMessage);
        sb.AppendLine(enoughtEnergyToHarvestersMessage);

        return sb.ToString().Trim();
    }
}

