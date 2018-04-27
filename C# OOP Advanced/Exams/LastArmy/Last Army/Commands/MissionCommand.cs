using System;
using System.Collections.Generic;

public class MissionCommand : Command
{
    public MissionCommand(IList<string> cmdArgs, IGameController gameController)
        : base(cmdArgs, gameController)
    {
    }

    public override void Execute()
    {
        var missionType = this.CmdArgs[0];
        var scoreToComplete = double.Parse(this.CmdArgs[1]);

        var mission = this.GameController.MissionFactory.CreateMission
            (missionType, scoreToComplete);
        var resultMessages = this.GameController.MissionControllerProp.PerformMission(mission);

        throw new ArgumentException(resultMessages);

    }
}

