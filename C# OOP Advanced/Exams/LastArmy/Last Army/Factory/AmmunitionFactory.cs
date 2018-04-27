
    using System;
    using System.Linq;

public class AmmunitionFactory : IAmmunitionFactory
{
    private Type[] weaponTypes;

    public AmmunitionFactory()
    {
        this.weaponTypes = new TypeCollector().GetAllInheritingTypes<IAmmunition>();
    }
        public IAmmunition CreateAmmunition(string ammunitionName)
        {
            var targetType = weaponTypes
                .FirstOrDefault(t => t.Name.Equals(ammunitionName, StringComparison.OrdinalIgnoreCase));

            if (targetType == null)
            {
                return null;
            }

            return (IAmmunition) Activator.CreateInstance(targetType);
        }
    }
