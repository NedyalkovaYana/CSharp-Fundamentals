using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.IO
{
   public class Writer : IWriter
   {
       public void WriteLine(string text) => Console.WriteLine(text);

   }
}
