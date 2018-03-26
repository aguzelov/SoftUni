using System;

namespace BashSoft.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AliasAttribute : Attribute
    {
        private string name;

        public AliasAttribute(string aliasName)
        {
            this.name = aliasName;
        }

        public string Name
        {
            get { return this.name; }
        }

        public override bool Equals(object obj)
        {
            return this.name.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}