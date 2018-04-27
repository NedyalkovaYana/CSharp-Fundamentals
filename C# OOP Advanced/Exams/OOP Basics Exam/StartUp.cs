using System;
using System.ComponentModel.Design;
using DungeonsAndCodeWizards.Core;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Interfaces;
using DungeonsAndCodeWizards.IO;


namespace DungeonsAndCodeWizards
{
    using Microsoft.Extensions.DependencyInjection;
    public class StartUp
	{
		public static void Main()
		{
            IReader reader = new Reader();
            IWriter writer = new Writer();

            IMainController controller = new MainController();
            ICharacterFactory characterFactory = new CharacterFactory();
            IItemFactory itemFactory = new ItemFactory();

            ICommandInterpreter interpreter = new CommandInterpreter
                (characterFactory, itemFactory, controller);

            var engine = new Engine(reader, writer, interpreter, controller);
            engine.Run();

		}
	}
}