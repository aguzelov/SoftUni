using System;

namespace BashSoft.Exceptions
{
    public class DuplicateEntryInStructureException : Exception
    {
        private const string DublicateEntry = "The {0} already exists in {1}.";

        public DuplicateEntryInStructureException(string message) : base(message)
        {
        }

        public DuplicateEntryInStructureException(string entry, string structure)
            : base(string.Format(DublicateEntry, entry, structure))
        {
        }
    }
}