using System.Collections;

public interface IMission
{
    string Name { get; }

    double EnduranceRequired { get; }

    double ScoreToComplete { get; }

    double WearLevelDecrement { get; }
    IEnumerable MissionWeapons { get; set; }
}
