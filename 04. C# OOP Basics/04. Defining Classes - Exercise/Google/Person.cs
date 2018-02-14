using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    public string Name { get; set; }
    public Company Company { get; set; }
    public Car Car { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Parent> Parents { get; set; }
    public List<Children> Childrens { get; set; }


    public Person()
    {
        Name = string.Empty;
       
        Pokemons = new List<Pokemon>();
        Parents = new List<Parent>();
        Childrens = new List<Children>();
    }

    public Person(string name):this()
    {
        Name = name;
    }

    public void AddCompany(Company company)
    {
        this.Company = company;
    }

    public void AddCar(Car car)
    {
        this.Car = car;
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.Pokemons.Add(pokemon);
    }

    public void AddParent(Parent parent)
    {
        this.Parents.Add(parent);
    }

    public void AddChildren(Children children)
    {
        this.Childrens.Add(children);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(Name);

        sb.AppendLine("Company:");
        if (Company != null)
        {
            sb.AppendLine(Company.ToString());
        }

        sb.AppendLine("Car:");
        if (Car != null)
        {
            sb.AppendLine(Car.ToString());
        }

        sb.AppendLine("Pokemon:");
        if (Pokemons.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, Pokemons.Select(p => p.ToString())));
        }

        sb.AppendLine("Parents:");
        if (Parents.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, Parents.Select(par => par.ToString())));
        }

        sb.AppendLine("Children:");
        if (Childrens.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, Childrens.Select(c => c.ToString())));
        }

        return sb.ToString();
    }
}
