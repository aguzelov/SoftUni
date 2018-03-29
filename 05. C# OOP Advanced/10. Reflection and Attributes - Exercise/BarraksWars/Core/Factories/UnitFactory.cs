using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using Contracts;
    using System;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type type = Type.GetType("_03BarracksFactory.Models.Units." + unitType);

            ConstructorInfo ctr = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];

            IUnit unit = (IUnit)ctr.Invoke(new object[] { });

            return unit;
        }
    }
}