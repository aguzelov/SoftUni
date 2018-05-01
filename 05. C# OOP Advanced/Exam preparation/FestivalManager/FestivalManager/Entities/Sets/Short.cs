namespace FestivalManager.Entities.Sets
{
    using System;

    public class Short : Set
    {
        private const int maxDuration = 15;

        public Short(string name)
            : base(name)
        {
        }

        public override TimeSpan MaxDuration => new TimeSpan(0, maxDuration, 0);
    }
}