using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        Dictionary<string, Person> persons = new Dictionary<string, Person>();

        string input = string.Empty;
        while((input = Console.ReadLine()) != "End")
        {
            string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string name = inputArr[0];
            Person person = null;

            if (persons.ContainsKey(name))
            {
                person = persons[name];
            }
            else
            {
                person = new Person(name);
            }

            switch (inputArr[1])
            {
                case "company":
                    string companyName = inputArr[2];
                    string deparment = inputArr[3];
                    decimal salary = decimal.Parse(inputArr[4]);
                    person.AddCompany(new Company(companyName, deparment, salary));
                    break;
                case "pokemon":
                    string pokemonName = inputArr[2];
                    string pokemonType = inputArr[3];
                    person.AddPokemon(new Pokemon(pokemonName, pokemonType));
                    break;
                case "parents":
                    string parentName = inputArr[2];
                    string parentBirthday = inputArr[3];
                    person.AddParent(new Parent(parentName, parentBirthday));
                    break;
                case "children":
                    string childrenName = inputArr[2];
                    string childrenBirthday = inputArr[3];
                    person.AddChildren(new Children(childrenName, childrenBirthday));
                    break;
                case "car":
                    string carMode = inputArr[2];
                    int carSpeed = int.Parse(inputArr[3]);
                    person.AddCar(new Car(carMode, carSpeed));
                    break;
            }

            if (!persons.ContainsKey(person.Name))
            {
                persons.Add(person.Name, new Person());
            }

            persons[person.Name] = person;
        }

        string nameForPrint = Console.ReadLine();
        Console.Write(persons[nameForPrint].ToString());
    }
}