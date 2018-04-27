using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    private Type[] providersTypes;

    public ProviderFactory()
    {
        this.providersTypes = new TypeCollector().GetAllInheritingTypes<IProvider>();
    }
    public IProvider GenerateProvider(IList<string> args)
    {

        var targetType = this.providersTypes.FirstOrDefault(p => p.Name.Equals(args[1] + "Provider"));

        if (targetType == null)
        {
            return null;
        }

        int id = int.Parse(args[2]);        
        double energyOutput = double.Parse(args[3]);

        return (IProvider) Activator.CreateInstance(targetType, id, energyOutput);
    }
}