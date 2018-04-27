using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.IO
{
    public class Reader : IReader
    {
        public string ReadLine() => Console.ReadLine();

    }
}
