using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Commands
{
   public class HealCommand : Command
    {
        public HealCommand(IList<string> cmdArgs, IMainController controller, ICharacterFactory characterFactory, IItemFactory itemFactory) : base(cmdArgs, controller, characterFactory, itemFactory)
        {
        }

        public override string Execute()
        {
            var healerName = this.CmdArgs[0];
            var healingReceiverName = this.CmdArgs[1];

            return controller.Heal(healerName, healingReceiverName);
        }
    }
}
