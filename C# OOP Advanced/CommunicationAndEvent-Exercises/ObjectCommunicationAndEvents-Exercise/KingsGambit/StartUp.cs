
using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var soliders = new List<Solider>();

        var king = new King(Console.ReadLine());
  
        var royalGuardsNames = Console.ReadLine().Split().ToList();
        foreach (var rgName in royalGuardsNames)
        {
            var royalGuard = new RoyalGuard(rgName);
            soliders.Add(royalGuard);
            king.UnderAttack += royalGuard.KingUnderAttack;
        }

        var footmansNames = Console.ReadLine().Split().ToList();
        foreach (var fmName in footmansNames)
        {
            var footman = new Footman(fmName);
            soliders.Add(footman);
            king.UnderAttack += footman.KingUnderAttack;
        }

        var inputCommands = string.Empty;

        while ((inputCommands = Console.ReadLine()) != "End")
        {
            var commands = inputCommands.Split();
            var command = commands[0];

            switch (command)
            {
                case "Attack":
                    king.OnUnderAttack();
                    break;
                case "Kill":
                    var killedSolider = soliders.FirstOrDefault(s => s.Name == commands[1]);

                    if (killedSolider != null)
                    {
                        king.UnderAttack -= killedSolider.KingUnderAttack;
                        soliders.Remove(killedSolider);
                    }
                    break;
            }
        }
    }
}

