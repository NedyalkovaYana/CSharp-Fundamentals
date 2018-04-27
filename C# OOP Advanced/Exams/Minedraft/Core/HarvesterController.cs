
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HarvesterController : IHarvesterController
{
    private List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory factory;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.factory = new HarvesterFactory();
        this.Mode = "Full";

    }
    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();
    public string Mode { get; private set; }
    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);
        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }

    public string Produce()
    {
        double storedEnergy = energyRepository.EnergyStored;
        double neededEnergy = harvesters.Select(h => h.EnergyRequirement).Sum();
        var mindsOre = harvesters.Select(h => h.OreOutput).Sum();

        if (Mode == "Energy")
        {
            neededEnergy = (neededEnergy * 20) / 100;
            mindsOre = (mindsOre * 20) / 100;

        }
       else if (Mode == "Half")
        {
            neededEnergy = (neededEnergy * 50) / 100;
            mindsOre = (mindsOre * 50) / 100;
        }

        if (neededEnergy <= storedEnergy)
        {
            energyRepository.TakeEnergy(neededEnergy);
            this.OreProduced += mindsOre;
        }

        else
        {
            return string.Format(Constants.OreOutputToday, 0);
        }

        return string.Format(Constants.OreOutputToday, mindsOre);
    }

    public double OreProduced { get; private set; }
    public string ChangeMode(string mode)
    {
        this.Mode = mode;

        foreach (var harvester in harvesters)
        {
            harvester.Durability -= 100;
        }

        harvesters = harvesters.Where(h => h.Durability >= 0).ToList();

        return  String.Format(Constants.SuccessfullChangeWorkingMode, mode);
    }
}

