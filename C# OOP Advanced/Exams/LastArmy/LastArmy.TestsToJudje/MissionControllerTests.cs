
using System;
using NUnit.Framework;

[TestFixture]
public class MissionControllerTests
{

    [Test]
    public void TestMissionsInQueue()
    {
        IArmy army = new Army();
        IWareHouse wareHouse = new Warehouse();
        var missionController = new MissionController(army, wareHouse);

        IMission mission = new Easy(20);

        Assert.AreEqual(missionController.PerformMission(mission).Trim(), "Mission on hold - Suppression of civil rebellion");
    }

    [Test]
    public void TestMissionsInQueueAfterMaxMissionCounter()
    {
        IArmy army = new Army();
        IWareHouse wareHouse = new Warehouse();
        var missionController = new MissionController(army, wareHouse);

        IMission mission = new Easy(20);

        string result = String.Empty;
        for (int i = 0; i < 5; i++)
        {
           result =  missionController.PerformMission(mission).Trim();
        }

        Assert.IsTrue(result.Contains("declined"));
    }

    [Test]
    public void TestFailMissionCounter()
    {
        IArmy army = new Army();
        IWareHouse wareHouse = new Warehouse();
        var missionController = new MissionController(army, wareHouse);

        IMission mission = new Easy(200);

        for (int i = 0; i < 3; i++)
        {
            missionController.PerformMission(mission);
        }

        missionController.FailMissionsOnHold();

        Assert.AreEqual(3, missionController.FailedMissionCounter);
    }

}

