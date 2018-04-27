
namespace P03_BarraksWars.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string NamespaceAsString = "P03_BarraksWars.Models.Units";
        public IUnit CreateUnit(string unitType)
        {
            var classType = Type.GetType($"{NamespaceAsString}.{unitType}");

            if (classType == null)
            {
                return null;
            }

            return (IUnit) Activator.CreateInstance(classType);
        }
    }
}
