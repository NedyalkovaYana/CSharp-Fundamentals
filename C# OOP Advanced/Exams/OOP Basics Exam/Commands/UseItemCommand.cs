using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Commands
{
   public class UseItemCommand : Command
    {
        public UseItemCommand(IList<string> cmdArgs, IMainController controller, ICharacterFactory characterFactory, IItemFactory itemFactory) 
            : base(cmdArgs, controller, characterFactory, itemFactory)
        {
        }

        public override string Execute()
        {
             var characterName = this.CmdArgs[0];
             var itemName = this.CmdArgs[1];
             return  controller.CharacterUseItem(characterName, itemName);
        }
    }
}
