using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Commands
{
    public class EndTurnCommand : Command
    {
        public EndTurnCommand(IList<string> cmdArgs, IMainController controller, ICharacterFactory characterFactory, IItemFactory itemFactory) : base(cmdArgs, controller, characterFactory, itemFactory)
        {
        }
        public override string Execute()
        {
           return this.controller.EndTurn();
        }
    }
}
