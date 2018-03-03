using System.Collections.Generic;
using System.Linq;

public class CleansingCenter : ICenter
{
    private string name;
    private Dictionary<string, List<IAnimal>> animalsByCenterName;
    private static List<IAnimal> cleansedAnimals = new List<IAnimal>();

    public CleansingCenter(string name)
    {
        Name = name;
        this.animalsByCenterName = new Dictionary<string, List<IAnimal>>();
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

    public static List<IAnimal> CleansedAnimals
    {
        get
        {
            return cleansedAnimals;
        }
    }

    public void AddAnimalsFromAdoptionCenter(KeyValuePair<string, IReadOnlyList<IAnimal>> centerNameAndAnimals)
    {
        if (!this.animalsByCenterName.ContainsKey(centerNameAndAnimals.Key))
        {
            this.animalsByCenterName.Add(centerNameAndAnimals.Key, new List<IAnimal>());
        }
        this.animalsByCenterName[centerNameAndAnimals.Key].AddRange(centerNameAndAnimals.Value);
    }

    public Dictionary<string, List<IAnimal>> Cleanse()
    {
        foreach (var animals in animalsByCenterName)
        {
            animals.Value.ForEach(a => a.CleansingStatus = "CLEANSED");

            CleansedAnimals.AddRange(animals.Value);
        }

        var cleansedAnimalsByCenter = new Dictionary<string, List<IAnimal>>(animalsByCenterName);
        animalsByCenterName.Clear();
        return cleansedAnimalsByCenter;
    }

    public int AnimalsAwaitingCleansing()
    {
        int result = 0;
        foreach (var pair in animalsByCenterName)
        {
            result += pair.Value.Where(a => a.CleansingStatus == "UNCLEANSED").Count();
        }
        return result;
    }
}