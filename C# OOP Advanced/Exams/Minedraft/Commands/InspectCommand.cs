
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class InspectCommand : Command
{
    //private IProviderController providerController;
    //private IHarvesterFactory harvesterController;
    //private IEnergyRepository repo;
    public InspectCommand(IList<string> arguments, ICommandInterpreter interpreter) 
        : base(arguments, interpreter)
    {
        
    }

    public override string Execute()
    {
        var idToCheck = int.Parse(Arguments[0]);

        var entities = new List<IEntity>();
        GetHarvesters(entities);
        GetProviders(entities);

        foreach (var entity in entities)
        {
            if (entity.ID == idToCheck)
            {
                return entity.ToString();
            }
        }

        return string.Format(Constants.NoEntityFound, idToCheck);
    }

    [RefreshEntities]
    private void GetHarvesters(List<IEntity> entities)
    {
        var harvesterEntities = this.Interpreter.HarvesterController
            .GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(h => h.Name == "Entities");

        var harvesters = (IReadOnlyCollection<IEntity>)
            harvesterEntities.GetValue(this.Interpreter.HarvesterController);


        entities.AddRange(harvesters);
    }

    [RefreshEntities]
    private void GetProviders(List<IEntity> entities)
    {
        var providerEntities = this.Interpreter.ProviderController
            .GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(h => h.Name == "Entities");
        
        var providers = (IReadOnlyCollection<IEntity>)
            providerEntities.GetValue(this.Interpreter.ProviderController);


        entities.AddRange(providers);
    }
}

