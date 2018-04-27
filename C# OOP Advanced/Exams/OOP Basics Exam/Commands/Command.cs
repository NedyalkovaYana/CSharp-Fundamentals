using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Commands
{
   public abstract class Command : ICommand
   {
       protected IMainController controller;
       protected ICharacterFactory characterFactory;
       protected IItemFactory itemFactory;
        protected Command(IList<string> cmdArgs, IMainController controller, ICharacterFactory characterFactory,
            IItemFactory itemFactory)
        {
            this.CmdArgs = cmdArgs;
            this.controller = controller;
            this.characterFactory = characterFactory;
            this.itemFactory = itemFactory;
        }

        protected IList<string> CmdArgs { get; }
        public abstract string Execute();

   }
}
