using System;

using System.Linq;
using System.Reflection;

namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            Type setType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if (setType == null)
            {
                throw new InvalidOperationException("Set not found!");
            }

            if (!typeof(ISet).IsAssignableFrom(setType))
            {
                throw new InvalidOperationException($"{type} is not a ISet!");
            }

            ISet set = (ISet)Activator.CreateInstance(setType, name);

            return set;
        }
    }
}