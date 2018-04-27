using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Commands
{
    class AttackCommand : Command
    {
        public AttackCommand(IList<string> cmdArgs, IMainController controller, ICharacterFactory characterFactory, IItemFactory itemFactory) 
            : base(cmdArgs, controller, characterFactory, itemFactory)
        {
        }

        public override string Execute()
        {
            var attackerName = this.CmdArgs[0];
            var receiverName = this.CmdArgs[1];

            return this.controller.Attack(attackerName, receiverName);
        }
    }
}
