using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Interfaces;


namespace DungeonsAndCodeWizards.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private Type[] commands;
        private ICharacterFactory characterFactory;
        private IItemFactory itemFactory;
        private IMainController controller;
        public CommandInterpreter(ICharacterFactory characterFactory, IItemFactory itemFactory, IMainController controller)
        {
            this.characterFactory = characterFactory;
            this.itemFactory = itemFactory;
            this.controller = controller;
            this.commands = new TypeCollector().GetAllInheritingTypes<ICommand>();
        }
        public string ProcessCommand(IList<string> args)
        {
            var commandName = args[0] + "Command";
            args = args.Skip(1).ToList();

            var commandType = this.commands
                .FirstOrDefault(c => c.Name.Equals(commandName));

            var commandInstance = (ICommand) Activator.CreateInstance(commandType, args, controller, characterFactory, itemFactory);
           return commandInstance.Execute();

        }
    }
}
