using System.Runtime.CompilerServices;

namespace P03_BarraksWars.Core.Command
{
    using Contracts;
   public abstract class Command : IExecutable
    { 
       private string[] data;
       private IRepository repository;
       private IUnitFactory unitFactory;

       protected Command(string[] data)
       {
           this.data = data;          
       }

       protected string[] Data
       {
           get { return this.data; }
           private set { this.data = value; }
       }
       public abstract string Execute();
    }
}
