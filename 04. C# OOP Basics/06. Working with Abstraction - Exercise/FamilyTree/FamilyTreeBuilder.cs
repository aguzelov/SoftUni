using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FamilyTreeBuilder
{
    private List<Person> FamilyTree { get; set; }
    private Person MainPerson { get; set; }

    public FamilyTreeBuilder(string mainPersonInput)
    {
        FamilyTree = new List<Person>();
        MainPerson = Person.CreatePerson(mainPersonInput);
        FamilyTree.Add(MainPerson);
    }

    public string Build()
    {
        StringBuilder resultBuilder = new StringBuilder();
        resultBuilder.AppendLine(this.MainPerson.ToString());

        resultBuilder.AppendLine("Parents:");
        foreach (var parent in this.MainPerson.Parents)
        {
            resultBuilder.AppendLine(parent.ToString());
        }

        resultBuilder.AppendLine("Children:");
        foreach (var child in this.MainPerson.Children)
        {
            resultBuilder.AppendLine(child.ToString());
        }

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }

    private Person FindOrCreate(string personInput)
    {
        var person = this.FamilyTree
            .FirstOrDefault(c => c.Name == personInput || c.Birthday == personInput);

        if (person == null)
        {
            person = Person.CreatePerson(personInput);
            this.FamilyTree.Add(person);
        }

        return person;
    }

    public void SetParentChildRelation(string parentInput, string childInput)
    {
        Person parent = FindOrCreate(parentInput);

        SetChild(parent, childInput);
    }

    private void SetChild(Person parent, string childInput)
    {
        var child = FindOrCreate(childInput);

        parent.Children.Add(child);
        child.Parents.Add(parent);
    }

    public void SetFullInfo(string name, string birthday)
    {
        var person = this.FamilyTree
            .FirstOrDefault(c => c.Name == name || c.Birthday == birthday);

        if (person == null)
        {
            person = new Person();
            this.FamilyTree.Add(person);
        }

        person.Name = name;
        person.Birthday = birthday;

        this.CheckForDuplicate(person);
    }

    private void CheckForDuplicate(Person person)
    {
        string name = person.Name;
        string birthday = person.Birthday;

        Person duplicate = this.FamilyTree
            .Where(p => p.Name == name || p.Birthday == birthday)
            .Skip(1)
            .FirstOrDefault();

        if (duplicate != null)
        {
            this.RemoveDuplicate(person, duplicate);
        }
    }

    private void RemoveDuplicate(Person person, Person duplicate)
    {
        this.FamilyTree.Remove(duplicate);

        person.Parents.AddRange(duplicate.Parents);
        //person.Parents = person.Parents.Distinct().ToList();
        foreach (var parent in duplicate.Parents)
        {
            ReplaceDuplicate(person, duplicate, parent.Children);
        }

        person.Children.AddRange(duplicate.Children);
        //person.Children = person.Children.Distinct().ToList();
        foreach (var child in duplicate.Children)
        {
            ReplaceDuplicate(person, duplicate, child.Parents);
        }
    }

    private static void ReplaceDuplicate(Person original, Person duplicate, List<Person> collection)
    {
        int duplicateIndex = collection.IndexOf(duplicate);
        if (duplicateIndex > -1)
        {
            collection[duplicateIndex] = original;
        }
        else
        {
            collection.Add(original);
        }
    }
}
