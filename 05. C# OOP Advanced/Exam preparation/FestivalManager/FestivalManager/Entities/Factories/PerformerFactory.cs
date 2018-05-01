namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PerformerFactory : IPerformerFactory
    {
        public IPerformer CreatePerformer(string name, int age)
        {
            Type sperformerType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(s => s.Name == "Performer");

            if (sperformerType == null)
            {
                throw new InvalidOperationException("Performer not found!");
            }

            if (!typeof(IPerformer).IsAssignableFrom(sperformerType))
            {
                throw new InvalidOperationException($"Performer is not a IPerformer!");
            }

            IPerformer performer = (IPerformer)Activator.CreateInstance(sperformerType, name, age);

            return performer;
        }
    }
}