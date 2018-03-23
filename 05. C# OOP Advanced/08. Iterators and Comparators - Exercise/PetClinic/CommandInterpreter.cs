using System;
using System.Collections.Generic;
using System.Linq;

public class CommandInterpreter
{
    private List<Clinic> clinics;
    private List<Pet> pets;

    public CommandInterpreter()
    {
        this.clinics = new List<Clinic>();
        this.pets = new List<Pet>();
    }

    public void Run()
    {
        int numberOfCommands = int.Parse(Console.ReadLine());
        while (numberOfCommands-- != 0)
        {
            string[] tokens = Console.ReadLine().Split();
            string command = tokens[0];
            string result = ExecuteCommand(command, tokens.Skip(1).ToArray());

            if (result != string.Empty)
                Console.WriteLine(result.Trim());
        }
    }

    private string ExecuteCommand(string command, string[] tokens)
    {
        string result = string.Empty;

        switch (command)
        {
            case "Create":
                string secondArg = tokens[0];
                if (secondArg == "Pet")
                {
                    CreatePet(tokens.Skip(1).ToArray());
                }
                else
                {
                    result = CreateClinic(tokens.Skip(1).ToArray());
                }
                break;

            case "Add":
                string petName = tokens[0];
                string clinicName = tokens[1];

                result = "Invalid Operation!";

                Pet pet = this.pets.FirstOrDefault(p => p.Name == petName);
                if (pet != null)
                {
                    Clinic clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
                    if (clinic != null)
                    {
                       
                        result = clinic.Add(pet).ToString();
                    }
                }
                break;

            case "Release":
                clinicName = tokens[0];
                Clinic clinicToRelease = this.clinics.FirstOrDefault(c => c.Name == clinicName);
                if (clinicToRelease != null)
                {
                    result = clinicToRelease.Release().ToString();
                }
                break;

            case "HasEmptyRooms":
                clinicName = tokens[0];
                result = this.clinics.FirstOrDefault(c => c.Name == clinicName)?.HasEmptyRooms.ToString();
                break;

            case "Print":
                if (tokens.Length == 2)
                {
                    clinicName = tokens[0];
                    int room = int.Parse(tokens[1]);

                    result = this.clinics.FirstOrDefault(c => c.Name == clinicName)?.Print(room);
                }
                else
                {
                    clinicName = tokens[0];

                    foreach (var p in this.clinics.FirstOrDefault(c => c.Name == clinicName))
                    {
                        if (p == null)
                        {
                            result += "Room empty" + Environment.NewLine;
                        }
                        else
                        {
                            result += p + Environment.NewLine;
                        }
                    }
                }
                break;
        }

        return result;
    }

    private string CreateClinic(string[] tokens)
    {
        string result = string.Empty;
        string name = tokens[0];
        int rooms = int.Parse(tokens[1]);

        try
        {
            Clinic clinic = new Clinic(name, new Pet[rooms]);

            this.clinics.Add(clinic);
        }
        catch (InvalidOperationException ioe)
        {
            result = ioe.Message;
        }

        return result;
    }

    private void CreatePet(string[] tokens)
    {
        string name = tokens[0];
        int age = int.Parse(tokens[1]);
        string kind = tokens[2];

        Pet pet = new Pet(name, age, kind);

        this.pets.Add(pet);
    }
}