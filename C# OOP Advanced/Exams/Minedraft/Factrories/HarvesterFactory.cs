using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    private Type[] harvesterTypes;
    public HarvesterFactory()
    {
        this.harvesterTypes = new TypeCollector().GetAllInheritingTypes<IHarvester>();
    }

    public IHarvester GenerateHarvester(IList<string> args)
    {
        var targetType = this.harvesterTypes
            .FirstOrDefault(t => t.Name.Equals(args[1] + "Harvester"));

        if (targetType == null)
        {
            return null;
        }
        //Harvester Hammer 20 100 100
        var id = int.Parse(args[2]);
        var oreOutput = double.Parse(args[3]);
        var energy = double.Parse((args[4]));

        return (IHarvester)Activator.CreateInstance(targetType, id, oreOutput, energy);
    }
}

