using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

public class SoldiersManager
{
    private List<ISolider> soliders;
    private List<IPrivate> privates;

    public SoldiersManager()
    {
        this.soliders = new List<ISolider>();
        this.privates = new List<IPrivate>();
    }

    internal string RegisterPrivate(string id, string firstName, string lastName, double salary)
    {
        var currentPrivate = new Private(id, firstName, lastName, salary);
        this.privates.Add(currentPrivate);

        return currentPrivate.ToString();
    }

    internal string RegisterLeutenantGeneral(string id, string firstName, string lastName, double salary,
        IEnumerable<string> privatesIds)
    {
        var leutenantGeneralPrivates = new List<IPrivate>();

        foreach (var privateId in privatesIds)
        {
            var currentPrivate = this.privates.FirstOrDefault(p => p.Id == privateId);
            if (currentPrivate != null)
            {
                leutenantGeneralPrivates.Add(currentPrivate);
            }
        }
        var currentSolider = new LeutenantGeneral(id, firstName, lastName, salary, leutenantGeneralPrivates);
        this.soliders.Add(currentSolider);

        return currentSolider.ToString();
    }

    public string RegisterEngineer(string id, string firstName, string lastName, double salary, string corps,
        string[] repairsData)
    {
        var repairs = new Queue<IRepair>();
        for (int i = 0; i < repairsData.Length; i++)
        {
            var partName = repairsData[i];
            i++;
            var hoursWorked = int.Parse(repairsData[i]);
            repairs.Enqueue(new Repair(partName, hoursWorked));
        }
        var currentSolider = new Engineer(id, firstName, lastName, salary, corps, repairs);
        this.soliders.Add(currentSolider);

        return currentSolider.ToString();
    }

    public string RegisterCommando(string id, string firstName, string lastName, double salary, string crops,
        string[] missionData)
    {
        var missions = new Queue<IMission>();

        for (int i = 0; i < missionData.Length; i++)
        {
            var codeName = missionData[i];
            i++;
            var state = missionData[i];

            try
            {
                missions.Enqueue(new Misson(codeName, state));
            }
            catch (ArgumentException)
            {
                continue;
            }
        }
        var currentSolider = new Commando(id, firstName, lastName, salary, crops, missions);
        this.soliders.Add(currentSolider);

        return currentSolider.ToString();
    }

    public string RegisterSpy(string id, string firstName, string lastName, int codeNumber)
    {
        var currentSolider = new Spy(id, firstName, lastName, codeNumber);
        this.soliders.Add(currentSolider);

        return currentSolider.ToString();
    }
}

