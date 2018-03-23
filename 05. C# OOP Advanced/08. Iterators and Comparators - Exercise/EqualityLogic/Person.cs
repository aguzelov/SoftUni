using System;
using System.Collections.Generic;
using System.Linq;

public class Person : IComparable
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public int Compare(Person x, Person y)
    {
        int result = x.Name.CompareTo(y.Name);

        if (result == 0)
        {
            result = x.Age.CompareTo(y.Age);
        }

        return result;
    }

    public int CompareTo(object obj)
    {
        if (!(obj is Person person))
        {
            throw new NullReferenceException();
        }

        return Compare(this, person);
    }

    private bool Equals(Person other)
    {
        return this.Name.Equals(other.Name) && this.Age.Equals(other.Age);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Person person))
        {
            throw new NullReferenceException();
        }

        return this.Equals(person);
    }

    public override int GetHashCode()
    {
        int hashCode = this.GetHashCodeOnProperties(this);
        return hashCode;
    }

    public int GetHashCodeOnProperties(Person inspect)
    {
        return GetListHashCode(inspect.GetType().GetProperties().Select(o => o.GetValue(inspect)));
    }

    public int GetListHashCode<T>(IEnumerable<T> sequence)
    {
        return sequence
            .Select(item => item.GetHashCode())
            .Aggregate((total, nextCode) => total ^ nextCode);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }
}