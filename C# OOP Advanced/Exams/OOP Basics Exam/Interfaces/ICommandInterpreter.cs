using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Interfaces
{
    public interface ICommandInterpreter
    {
        string ProcessCommand(IList<string> args);
    }
}
