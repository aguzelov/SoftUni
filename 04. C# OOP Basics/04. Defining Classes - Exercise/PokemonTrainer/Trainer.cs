using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    public string Name { get; set; }
    public long NumberOfBadges { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public Trainer()
    {
        NumberOfBadges = 0;
        Pokemons = new List<Pokemon>();
    }

    public Trainer(string name, Pokemon pokemon) : this()
    {
        Name = name;
        Pokemons.Add(pokemon);
    }
    
    public void AddPokemon(Pokemon pokemon)
    {

        Pokemons.Add(pokemon);
    }

    public void ElementCheck(string element)
    {
        int count = Pokemons.Where(e => e.Element == element).Count();
        
        if(count == 0)
        {
            Pokemons.ForEach(p => p.Health -= 10);
            Pokemons.RemoveAll(p => p.Health <= 0);
        }
        else
        {
            NumberOfBadges += 1;
        }
    }


    public bool Equals(Trainer other)
    {
        return this.Name == other.Name;
    }

    public override bool Equals(object obj)
    {
        var item = obj as Trainer;
        if(item == null)
        {
            return false;
        }

        return this.Equals(item);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}