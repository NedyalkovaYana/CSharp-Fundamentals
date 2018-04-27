
using System;
using System.Collections.Generic;

public class SoldierCommand : Command
{
    public SoldierCommand(IList<string> cmdArgs, IGameController gameController) 
        : base(cmdArgs, gameController)
    {
    }

    public override void Execute()
    {
        var type = this.CmdArgs[0];
        var name = this.CmdArgs[1];
        var age = int.Parse(this.CmdArgs[2]);
        var experience = double.Parse(this.CmdArgs[3]);
        var endurance = double.Parse(this.CmdArgs[4]);

        var soldier = this.GameController.SoldierFactory
                      .CreateSoldier(type, name, age, experience, endurance);

        var isEquipted =  this.GameController.WareHouse.TryEquipSoldier(soldier);

        if (!isEquipted)
        {
            throw new ArgumentException
                (String.Format(OutputMessages.SoldierNotEquipedExceptionMessage, type, name));
        }

        this.GameController.Army.AddSoldier(soldier);
    }
}

