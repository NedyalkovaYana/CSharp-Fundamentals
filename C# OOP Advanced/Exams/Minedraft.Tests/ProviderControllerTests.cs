
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class ProviderControllerTests
{

    [Test]
    public void TestRegister()
    {
        List<IProvider> providers = new List<IProvider>();
        IEnergyRepository repository = new EnergyRepository();
        IProviderFactory factory = new ProviderFactory();
        IProviderController controller = new ProviderController(repository);

        var provider1 = controller.Register(new List<string> { "Provider", "Pressure", "40", "100" });
        var provider2 = controller.Register(new List<string> { "Provider", "Solar", "40", "100" });
        var provider3 = controller.Register(new List<string> { "Provider", "Standart", "40", "100" });

        //var providers = GetProviders();

        Assert.AreEqual("Successfully registered PressureProvider", provider1);
        Assert.AreEqual("Successfully registered SolarProvider", provider2);
        Assert.AreEqual("Successfully registered StandartProvider", provider3);
    }

    [Test]
    public void TestProduce()
    {
        List<IProvider> providers = new List<IProvider>();
        IEnergyRepository repository = new EnergyRepository();
        IProviderFactory factory = new ProviderFactory();
        IProviderController controller = new ProviderController(repository);

        var provider1 = controller.Register(new List<string> { "Provider", "Pressure", "40", "100" });

        var returnMessage = controller.Produce();

        Assert.AreEqual("Produced 200 energy today!", returnMessage);
        Assert.AreEqual(200, controller.TotalEnergyProduced);
    }

    [Test]
    [TestCase(20)]
    [TestCase(5)]
    [TestCase(10)]
    public void TestRepair(double value)
    {
        IEnergyRepository repository = new EnergyRepository();
        IProviderController controller = new ProviderController(repository);

        var res = string.Empty;
        res = controller.Repair(value);

        Assert.AreEqual($"Providers are repaired by {value}", res.Trim());
    }
}

