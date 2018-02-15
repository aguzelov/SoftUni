using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string Name { get; set; }
    public string Birthday { get; set; }
    public List<Person> Childrens { get; set; }

    public Person()
    {
        Childrens = new List<Person>();
    }

    public Person(string nameOrBirthday) : this()
    {
        if (nameOrBirthday.Contains("/"))
        {
            Birthday = nameOrBirthday;
        }
        else
        {
            Name = nameOrBirthday;
        }
    }

    public Person(string name, string birthday) : this()
    {
        Name = name;
        Birthday = birthday;
    }

    public void AddName(string name)
    {
        Name = name;
    }

    public void AddBirthday(string birthday)
    {
        Birthday = birthday;
    }

    public void AddChild(Person child)
    {
        Childrens.Add(child);
    }

    public void AddChildren(List<Person> children)
    {
        Childrens.AddRange(children);
    }

    public void UpdateChiren(Person person)
    {
        Person child = Childrens.FirstOrDefault(n => n.Name == person.Name);

        if (child == null)
        {
            child = Childrens.FirstOrDefault(n => n.Birthday == person.Birthday);
            if(child != null)
            {
                child.Name = person.Name;
            }

            return;
        }

        child.Birthday = person.Birthday;
    }

    public override string ToString()
    {
        return $"{Name} {Birthday}";
    }

    public bool Equals(Person other)
    {
        return this.Name == other.Name && this.Birthday == other.Birthday;
    }

    public override bool Equals(object obj)
    {
        var person = obj as Person;
        if (person == null) return false;

        return this.Equals(person);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
