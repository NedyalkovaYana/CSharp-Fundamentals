using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Commands
{
   public class AddItemToPoolCommand : Command
   {
        public AddItemToPoolCommand(IList<string> cmdArgs, IMainController controller, ICharacterFactory characterFactory, IItemFactory itemFactory) 
            : base(cmdArgs, controller, characterFactory, itemFactory)
        {
        }

        public override string Execute()
        {
            var item = itemFactory.CreateItem(this.CmdArgs);
            if (item == null)
            {
                return null;
            }

            controller.AddItem(item);

            return string.Format(Messages.AddItemToPool, item.GetType().Name);
        }
   }
}
