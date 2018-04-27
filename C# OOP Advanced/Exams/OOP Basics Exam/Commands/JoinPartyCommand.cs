using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Commands
{
    public class JoinPartyCommand : Command
    {
        public JoinPartyCommand(IList<string> cmdArgs, IMainController controller, ICharacterFactory characterFactory, IItemFactory itemFactory)
            : base(cmdArgs, controller, characterFactory, itemFactory)
        {
        }
        public override string Execute()
        {
            var character =  characterFactory.CreateCharacter(CmdArgs);

            this.controller.AddCharacter(character);

            return String.Format(Messages.SucsessfullAddToParty, character.Name);
          
        }
    }
}
