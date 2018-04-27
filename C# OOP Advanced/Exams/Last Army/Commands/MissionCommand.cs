using System;
using System.Collections.Generic;
using System.Linq;

public class MissionCommand : Command
{
    public MissionCommand(IList<string> cmdArgs, IGameController gameController)
        : base(cmdArgs, gameController)
    {
    }

    public override void Execute()
    {
        var missionType = CmdArgs[0];
        var scoreToComplete = double.Parse(CmdArgs[1]);

        var mission = this.GameController.MissionFactory.CreateMission(missionType, scoreToComplete);
        var resultMessage = this.GameController.MissionControllerProp.PerformMission(mission);

        throw new ArgumentException(resultMessage);
    }
}

