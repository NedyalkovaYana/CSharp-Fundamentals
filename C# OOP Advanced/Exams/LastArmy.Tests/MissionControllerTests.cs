
using NUnit.Framework;

[TestFixture]
public class MissionControllerTests
{
    private MissionController sut;
    private IArmy army;
    private IWareHouse wareHouse;

    [SetUp]
    public void TestInit()
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.sut = new MissionController(army, wareHouse);
    }

    [Test]
    public void PerformMissionEnqueuesMissionCorrectly()
    {
        this.sut.PerformMission(new Easy(50));

        Assert.AreEqual(1, this.sut.Missions.Count);
    }

    [Test]
    public void PerformMissionWithoutEnoughSoldiersReturnsCorrectMessage()
    {
        var mission = new Hard(20);

        var message = this.sut.PerformMission(mission).Trim();

        Assert.AreEqual($"Mission on hold - {mission.Name}", message);
    }

    [Test]
    public void PerformMissionCannotEnqueMoreThanThreeMissionsOnHold()
    {
        var mission1 = new Hard(20);
        var mission2 = new Hard(20);
        var mission3 = new Hard(20);
        var mission4 = new Hard(20);

        this.sut.PerformMission(mission1);
        this.sut.PerformMission(mission2);
        this.sut.PerformMission(mission3);
        this.sut.PerformMission(mission4);

        Assert.AreEqual(3, this.sut.Missions.Count);
    }

    [Test]
    public void PerformMissionWithEnoughSoldiersReturnsCorrectMessage()
    {
        var mission = new Easy(20);

        this.wareHouse.AddAmmunitions("Gun", 10);
        this.wareHouse.AddAmmunitions("AutomaticMachine", 10);
        this.wareHouse.AddAmmunitions("Helmet", 10);

        var soldier3 = new Ranker("Soldier 3", 30, 50, 50);
        this.army.AddSoldier(soldier3);
        this.wareHouse.EquipArmy(this.army);

        var message = this.sut.PerformMission(mission).Trim();

        Assert.AreEqual($"Mission completed - {mission.Name}", message);
    }

    [Test]
    public void PerformMissionSuccessfullyIncreasesSucceededMissionsCounter()
    {
        var mission = new Easy(20);

        this.wareHouse.AddAmmunitions("Gun", 10);
        this.wareHouse.AddAmmunitions("AutomaticMachine", 10);
        this.wareHouse.AddAmmunitions("Helmet", 10);

        var soldier3 = new Ranker("Soldier 3", 30, 50, 50);
        this.army.AddSoldier(soldier3);
        this.wareHouse.EquipArmy(this.army);

        var message = this.sut.PerformMission(mission).Trim();

        Assert.AreEqual(1, this.sut.SuccessMissionCounter);
    }

    [Test]
    public void PerformMissionDeclinesFirstWaitingMissionWhenTheWaitingOnesAreMoreThanThree()
    {
        var mission = new Hard(20);
        this.sut.PerformMission(mission);
        this.sut.PerformMission(mission);
        this.sut.PerformMission(mission);

        var message = this.sut.PerformMission(mission).Trim();

        Assert.IsTrue(message.StartsWith($"Mission declined - {mission.Name}"));
    }

    [Test]
    public void FailMissionsOnHoldIncreasesFailedMissionCounterCorrectly()
    {
        var mission = new Hard(20);

        this.sut.PerformMission(mission);

        this.sut.FailMissionsOnHold();

        Assert.AreEqual(1, this.sut.FailedMissionCounter);
    }

    [Test]
    public void FailedMissionCounterDisplaysCorrectlyIfNone()
    {
        this.sut.PerformMission(new Easy(0));

        Assert.AreEqual(0, sut.FailedMissionCounter);
    }

    [Test]
    public void FailIfMoreThanThreeMissions()
    {
        this.sut.Missions.Enqueue(new Easy(0));
        this.sut.Missions.Enqueue(new Easy(0));
        this.sut.Missions.Enqueue(new Easy(0));

        this.sut.PerformMission(new Easy(0));

        Assert.AreEqual(1, this.sut.FailedMissionCounter);
    }
}

