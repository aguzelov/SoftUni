using System;

[AttributeUsage(AttributeTargets.Class)]
public class RefreshEntitiesAttribute : Attribute
{
    private string name;
    private string type;

    public RefreshEntitiesAttribute(string aliasName)
    {
        this.name = aliasName;
    }

    public RefreshEntitiesAttribute(string aliasName, string type)
        : this(aliasName)
    {
        this.type = type;
    }

    public string Name => this.name;

    public string Type => this.type;

    public override bool Equals(object obj)
    {
        return this.name.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}