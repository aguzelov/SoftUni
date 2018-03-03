using System.Collections.Generic;
using System.Linq;

public class AdoptionCenter : ICenter
{
    private string name;
    private List<IAnimal> animals;
    private static List<IAnimal> adoptedAnimals = new List<IAnimal>();

    public AdoptionCenter(string name)
    {
        Name = name;
        this.animals = new List<IAnimal>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            this.name = value;
        }
    }

    public static List<IAnimal> AdoptedAnimals
    {
        get
        {
            return adoptedAnimals;
        }
    }

    public KeyValuePair<string, IReadOnlyList<IAnimal>> SendForCleansing()
    {
        var pair = new KeyValuePair<string, IReadOnlyList<IAnimal>>(
            this.name,
            this.animals.Where(a => a.CleansingStatus == "UNCLEANSED").ToList()
            );

        foreach (var animal in pair.Value)
        {
            animals.Remove(animal);
        }
        return pair;
    }

    public KeyValuePair<string, IReadOnlyList<IAnimal>> SendForCastration()
    {
        var currentAnimals = new List<IAnimal>(this.animals);

        var pair = new KeyValuePair<string, IReadOnlyList<IAnimal>>(
            this.name,
            currentAnimals
            );

        this.animals.Clear();
        return pair;
    }

    public void Adopt()
    {
        foreach (var animal in animals)
        {
            if (animal.CleansingStatus == "CLEANSED")
            {
                adoptedAnimals.Add(animal);
            }
        }
        this.animals.RemoveAll(a => a.CleansingStatus == "CLEANSED");
    }

    public void AddAnimal(IAnimal animal)
    {
        this.animals.Add(animal);
    }

    public void AddAnimals(List<IAnimal> animalsFromCleansing)
    {
        this.animals.AddRange(animalsFromCleansing);
    }

    public int AnimalsAwaitingAdoption()
    {
        int result = this.animals.Where(a => a.CleansingStatus == "CLEANSED").Count();
        return result;
    }
}