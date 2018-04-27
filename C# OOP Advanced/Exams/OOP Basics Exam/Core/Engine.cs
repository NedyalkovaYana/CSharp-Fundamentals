using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Core
{
    class Engine
    {
        private bool isRunning;
        private IReader reader;
        private IWriter writer;
        private ICommandInterpreter commandInterpreter;
        private IMainController controller;
        public Engine( IReader reader, IWriter writer,
            ICommandInterpreter commandInterpreter, IMainController controller)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
            this.controller = controller;
        }
        public void Run()
        {
            var input = reader.ReadLine();
            this.isRunning = true;
            while (isRunning)
            {
                var result = this.commandInterpreter.ProcessCommand(input.Split().ToList());
                if (result == null)
                {
                    input = this.reader.ReadLine();
                    continue;
                }
                writer.WriteLine(result);

                if (this.controller.IsGameOver() || this.isRunning == false)
                {
                    this.writer.WriteLine("Final stats:");
                    this.writer.WriteLine(this.controller.CharacterGetStatus());
                    this.isRunning = false;
                }
               
                input = this.reader.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    this.isRunning = false;
                    return;
                }
            }
        }
    }
}
