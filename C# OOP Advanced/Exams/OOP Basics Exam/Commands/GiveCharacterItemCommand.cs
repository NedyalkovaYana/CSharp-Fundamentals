using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Commands
{
    public class GiveCharacterItemCommand : Command
    {
        public GiveCharacterItemCommand(IList<string> cmdArgs, IMainController controller, ICharacterFactory characterFactory, IItemFactory itemFactory) : base(cmdArgs, controller, characterFactory, itemFactory)
        {
        }

        public override string Execute()
        {
            var giverName = this.CmdArgs[0];
            var receiverName = this.CmdArgs[1];
            var itemName = this.CmdArgs[2];

            return controller.CharacterGiveItem(giverName, receiverName, itemName);
        }
    }
}
