using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Commands
{
    public class UseItemOnCommand : Command
    {
        public UseItemOnCommand(IList<string> cmdArgs, IMainController controller, ICharacterFactory characterFactory, IItemFactory itemFactory) : base(cmdArgs, controller, characterFactory, itemFactory)
        {
        }

        public override string Execute()
        {
            var givenName = this.CmdArgs[0];
            var reciverName = this.CmdArgs[1];
            var itemName = this.CmdArgs[2];
           return controller.CharacterUseItemOn(givenName, reciverName, itemName);
        }
    }
}
