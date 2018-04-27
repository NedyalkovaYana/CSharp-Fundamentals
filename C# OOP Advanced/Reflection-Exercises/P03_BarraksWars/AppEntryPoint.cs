using P03_BarraksWars.Contracts;
using P03_BarraksWars.Core;
using P03_BarraksWars.Core.Factories;
using P03_BarraksWars.Data;

namespace P03_BarraksWars
{
    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            UnitRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}
