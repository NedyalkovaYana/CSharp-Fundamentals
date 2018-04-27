using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{   
    using Exceptions;

    [Alias(InitializingCommand)]
    public class ShowWantedDataCommand : Command
    {
        private const string InitializingCommand = "show";

        [Inject]
        private IDatabase repository;

        public ShowWantedDataCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                var course = this.Data[1];
                repository.GetAllStudentsFromCourse(course);
            }
            else if (this.Data.Length == 3)
            {
                var course = this.Data[1];
                var username = this.Data[2];
                repository.GetStudentScoresFromCourse(course, username);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}