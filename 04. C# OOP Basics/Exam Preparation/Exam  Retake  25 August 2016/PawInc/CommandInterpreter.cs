using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class CommandInterpreter
{
    private static List<AdoptionCenter> adoptionCenters = new List<AdoptionCenter>();
    private static List<CleansingCenter> cleansingCenters = new List<CleansingCenter>();
    private static List<CastrationCenter> castrationCenters = new List<CastrationCenter>();

    public static void Execute()
    {
        while (true)
        {
            string[] commandArgs = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            string command = commandArgs[0];
            switch (command)
            {
                case "RegisterCastrationCenter":
                    string centerName = commandArgs[1];
                    castrationCenters.Add(new CastrationCenter(centerName));
                    break;

                case "RegisterCleansingCenter":
                    centerName = commandArgs[1];
                    cleansingCenters.Add(new CleansingCenter(centerName));
                    break;

                case "RegisterAdoptionCenter":
                    centerName = commandArgs[1];
                    adoptionCenters.Add(new AdoptionCenter(centerName));
                    break;

                case "RegisterDog":
                    IAnimal dog = null;
                    try
                    {
                        dog = AnimalFactory.CreateAnimal("Dog", commandArgs[1], commandArgs[2], commandArgs[3]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                    string adoadoptionCenterName = commandArgs[4];

                    AdoptionCenter center = adoptionCenters.FirstOrDefault(c => c.Name == adoadoptionCenterName);

                    center.AddAnimal(dog);

                    break;

                case "RegisterCat":
                    IAnimal cat = null;
                    try
                    {
                        cat = AnimalFactory.CreateAnimal("Cat", commandArgs[1], commandArgs[2], commandArgs[3]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    adoadoptionCenterName = commandArgs[4];

                    center = adoptionCenters.FirstOrDefault(c => c.Name == adoadoptionCenterName);

                    center.AddAnimal(cat);
                    break;

                case "SendForCleansing":
                    adoadoptionCenterName = commandArgs[1];
                    string cleansingCenterName = commandArgs[2];

                    AdoptionCenter adoadoptionCenter = adoptionCenters.FirstOrDefault(c => c.Name == adoadoptionCenterName);
                    CleansingCenter cleansingCenter = cleansingCenters.FirstOrDefault(c => c.Name == cleansingCenterName);

                    cleansingCenter.AddAnimalsFromAdoptionCenter(adoadoptionCenter.SendForCleansing());
                    break;

                case "SendForCastration":
                    adoadoptionCenterName = commandArgs[1];
                    string castrationCenterName = commandArgs[2];

                    adoadoptionCenter = adoptionCenters.FirstOrDefault(c => c.Name == adoadoptionCenterName);

                    CastrationCenter castrationCenter = castrationCenters.FirstOrDefault(c => c.Name == castrationCenterName);

                    castrationCenter.AddAnimalsFromAdoptionCenter(adoadoptionCenter.SendForCastration());
                    break;

                case "Cleanse":
                    cleansingCenterName = commandArgs[1];
                    cleansingCenter = cleansingCenters.FirstOrDefault(c => c.Name == cleansingCenterName);

                    var centerAndAnimals = cleansingCenter.Cleanse();

                    foreach (var pair in centerAndAnimals)
                    {
                        adoadoptionCenterName = pair.Key;
                        adoadoptionCenter = adoptionCenters.FirstOrDefault(c => c.Name == adoadoptionCenterName);

                        adoadoptionCenter.AddAnimals(pair.Value);
                    }
                    break;

                case "Castrate":
                    castrationCenterName = commandArgs[1];
                    castrationCenter = castrationCenters.FirstOrDefault(c => c.Name == castrationCenterName);

                    centerAndAnimals = castrationCenter.Castrate();

                    foreach (var pair in centerAndAnimals)
                    {
                        adoadoptionCenterName = pair.Key;
                        adoadoptionCenter = adoptionCenters.FirstOrDefault(c => c.Name == adoadoptionCenterName);

                        adoadoptionCenter.AddAnimals(pair.Value);
                    }
                    break;

                case "Adopt":
                    adoadoptionCenterName = commandArgs[1];
                    adoadoptionCenter = adoptionCenters.FirstOrDefault(c => c.Name == adoadoptionCenterName);

                    adoadoptionCenter.Adopt();
                    break;

                case "CastrationStatistics":
                    StringBuilder sb = new StringBuilder();

                    sb.Append($"Paw Inc. Regular Castration Statistics{Environment.NewLine}");
                    sb.Append($"Castration Centers: {castrationCenters.Count}{Environment.NewLine}");

                    string castratedAnimals = CastrationCenter.CastratedAnimals.Count == 0 ? "None" : string.Join(", ", CastrationCenter.CastratedAnimals.OrderBy(a => a.Name));
                    sb.Append($"Castrated Animals: {castratedAnimals}");

                    Console.WriteLine(sb.ToString());
                    break;

                case "Paw Paw Pawah":
                    sb = new StringBuilder();
                    sb.Append($"Paw Incorporative Regular Statistics{Environment.NewLine}");

                    sb.Append($"Adoption Centers: {adoptionCenters.Count}{Environment.NewLine}");
                    sb.Append($"Cleansing Centers: {cleansingCenters.Count}{Environment.NewLine}");

                    string adoptedAnimals = AdoptionCenter.AdoptedAnimals.Count == 0 ? "None" : string.Join(", ", AdoptionCenter.AdoptedAnimals.OrderBy(a => a.Name));
                    sb.Append($"Adopted Animals: {adoptedAnimals}{Environment.NewLine}");

                    string cleansedAnimals = CleansingCenter.CleansedAnimals.Count == 0 ? "None" : string.Join(", ", CleansingCenter.CleansedAnimals.OrderBy(a => a.Name));
                    sb.Append($"Cleansed Animals: {cleansedAnimals}{Environment.NewLine}");

                    int amountOfAnimalsWaitingForAdoption = adoptionCenters.Sum(a => a.AnimalsAwaitingAdoption());
                    sb.Append($"Animals Awaiting Adoption: {amountOfAnimalsWaitingForAdoption}{Environment.NewLine}");

                    int amountOfAnimalsWaitingForCleansing = cleansingCenters.Sum(a => a.AnimalsAwaitingCleansing());
                    sb.Append($"Animals Awaiting Cleansing: {amountOfAnimalsWaitingForCleansing}");

                    Console.WriteLine(sb.ToString());
                    return;
            }
        }
    }
}