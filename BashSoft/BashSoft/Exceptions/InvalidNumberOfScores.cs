using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Exceptions
{
    public class InvalidNumberOfScores : Exception
    {
        private const string NullOrEmptyValue = "The number of scores for the given course is greater than the possible.";

        public InvalidNumberOfScores()
            : base(NullOrEmptyValue)
        {
        }

        public InvalidNumberOfScores(string message)
            : base(message)
        {
        }

    }
}
