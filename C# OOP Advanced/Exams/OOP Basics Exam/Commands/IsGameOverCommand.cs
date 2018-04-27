
using System.Collections.Generic;
using DungeonsAndCodeWizards.Commands;
using DungeonsAndCodeWizards.Interfaces;

public class IsGameOverCommand : Command
{
    public IsGameOverCommand(IList<string> cmdArgs, IMainController controller, ICharacterFactory characterFactory, IItemFactory itemFactory)
        : base(cmdArgs, controller, characterFactory, itemFactory)
    {
    }

    public override string Execute()
    {
        var isGameOver = "GameOver";
        var result =  this.controller.IsGameOver();

        if (result != true)
        {
            isGameOver = "GameNotOver";
            this.controller.CharacterGetStatus();
        }

        return isGameOver;
    }
}

