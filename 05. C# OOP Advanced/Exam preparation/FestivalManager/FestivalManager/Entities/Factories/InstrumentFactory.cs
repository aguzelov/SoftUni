namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            Type instrumentType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(s => s.Name == type);

            if (instrumentType == null)
            {
                throw new InvalidOperationException($"{type} not found!");
            }

            if (!typeof(IInstrument).IsAssignableFrom(instrumentType))
            {
                throw new InvalidOperationException($"{type} is not a IInstrument!");
            }

            IInstrument instrument = (IInstrument)Activator.CreateInstance(instrumentType);

            return instrument;
        }
    }
}