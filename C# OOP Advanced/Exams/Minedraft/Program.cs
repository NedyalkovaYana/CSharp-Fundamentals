public class Program
{
    public static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConosoleWriter();

        IEnergyRepository energyRepository = new EnergyRepository();
        IProviderController providerController = new ProviderController(energyRepository);
        IHarvesterController harvesterController = new HarvesterController(energyRepository);
        ICommandInterpreter interpreter = new CommandInterpreter(harvesterController, providerController);

        Engine engine = new Engine(reader, writer, interpreter);
        engine.Run();
    }
}