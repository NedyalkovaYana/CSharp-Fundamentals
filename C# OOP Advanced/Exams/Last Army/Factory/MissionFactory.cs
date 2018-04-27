using System;
using System.Linq;


internal class MissionFactory : IMissionFactory
{
    private Type[] missionFactory;
    public MissionFactory()
    {
        this.missionFactory = new TypeCollector().GetAllInheritingTypes<IMission>();
    }

    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        var targetType = this.missionFactory
            .FirstOrDefault(m => m.Name.Equals(difficultyLevel, StringComparison.OrdinalIgnoreCase));

        if (targetType == null)
        {
            return null;
        }

        return (IMission)Activator.CreateInstance
            (targetType, neededPoints);
    }
}
