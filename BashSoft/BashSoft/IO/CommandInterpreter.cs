using System;
using System.Linq;
using System.Reflection;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.IO.Commands;


namespace BashSoft
{
    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string command = data[0].ToLower();
            try
            {
                this.ParseCommand(input, data, command);
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }

        private IExecutable ParseCommand(string input, string[] data, string command)
        {
            object[] parametersForConstruction = new object[]
            {
                input, data
            };

            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(t => t.GetCustomAttributes(typeof(AliasAttribute))
                                .Where(a => a.Equals(command))
                                .ToArray()
                                .Length > 0);

            var interpreterType = typeof(CommandInterpreter);
            Command exe = (Command) Activator.CreateInstance(commandType, parametersForConstruction);

            var fieldsOfCommand = commandType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldsOfInterpreter = interpreterType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fieldsOfCommand)
            {
                var injectAttribute = field.GetCustomAttributes(typeof(InjectAttribute));
                if (injectAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(f => f.FieldType == field.FieldType))
                    {
                        field.SetValue(
                            exe, 
                            fieldsOfInterpreter
                            .First(f => f.FieldType == field.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return exe;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split();
            string commandName = data[0];

            try
            {
                IExecutable command = this.ParseCommand(input, data, commandName);
                command.Execute();
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }
    }
}
