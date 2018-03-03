using System.Collections.Generic;

public class CastrationCenter : ICenter
{
    private string name;
    private Dictionary<string, List<IAnimal>> animalsByCenterName;
    private static List<IAnimal> castratedAnimals = new List<IAnimal>();

    public CastrationCenter(string name)
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

    public static List<IAnimal> CastratedAnimals
    {
        get
        {
            return castratedAnimals;
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

    public Dictionary<string, List<IAnimal>> Castrate()
    {
        foreach (var animals in animalsByCenterName)
        {
            castratedAnimals.AddRange(animals.Value);
        }

        var castratedAnimalsByCenter = new Dictionary<string, List<IAnimal>>(animalsByCenterName);
        animalsByCenterName.Clear();
        return castratedAnimalsByCenter;
    }
}