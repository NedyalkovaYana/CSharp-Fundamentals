
using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var soldiers = new ModifiedDictionary();
        

        var king = new King(Console.ReadLine());

        var royalGuardsNames = Console.ReadLine().Split().ToList();
        foreach (var rgName in royalGuardsNames)
        {
            var royalGuard = new RoyalGuard(rgName);
            soldiers.Add(rgName, royalGuard);
            royalGuard.SoliderDeath += soldiers.HandleSoliderDeath;
            royalGuard.SoliderDeath += king.OnSoliderDeath;
            king.UnderAttack += royalGuard.KingUnderAttack;
        }

        var footmansNames = Console.ReadLine().Split().ToList();
        foreach (var fmName in footmansNames)
        {
            var footman = new Footman(fmName);
            soldiers.Add(fmName, footman);
            footman.SoliderDeath += soldiers.HandleSoliderDeath;
            footman.SoliderDeath += king.OnSoliderDeath;
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
                    var soliderToRemove = soldiers[commands[1]];
                    soliderToRemove.RespondToAttack();                
                    break;
            }
        }
    }
}

