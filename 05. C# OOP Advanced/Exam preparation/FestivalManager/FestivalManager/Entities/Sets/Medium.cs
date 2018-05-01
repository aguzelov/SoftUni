namespace FestivalManager.Entities.Sets
{
    using System;

    public class Medium : Set
    {
        private const int maxDuration = 40;

        public Medium(string name)
            : base(name)
        {
        }

        public override TimeSpan MaxDuration => new TimeSpan(0, maxDuration, 0);
    }
}