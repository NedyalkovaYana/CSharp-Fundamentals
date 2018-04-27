using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{

    using Exceptions;

   [Alias(InitializingCommand)]
    public class ChangeAbsolutePathCommand : Command
    {
        private const string InitializingCommand = "cdAbs";

        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeAbsolutePathCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var absPath = this.Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryAbsoulute(absPath);
        }
    }
}