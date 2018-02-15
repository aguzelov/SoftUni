using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    static void Main()
    {
        string personInput = Console.ReadLine();
        
        List<Person> persons = new List<Person>();

        string input = string.Empty;
        while ((input = Console.ReadLine().Trim()) != "End")
        {   
            if (input.Contains(" - "))
            {
                string[] pair = input.Split(" - ");

                //Parent
                Person parent = null;
                if (pair[0].Contains("/"))
                {
                    string parentBirthday = pair[0];
                    parent = persons.FirstOrDefault(p => p.Birthday == parentBirthday);
                    
                }
                else
                {
                    string parentName = pair[0];
                    parent = persons.FirstOrDefault(p => p.Name == parentName);
                    
                }

                if(parent == null)
                {
                    parent = new Person(pair[0]);
                    persons.Add(parent);
                }

                //Child
                Person child = new Person(pair[1]);
                
                parent.AddChild(child);
            }
            else
            {
                string[] personInfo = input.Split(" ");
                string name = personInfo[0] + " " + personInfo[1];
                string birthday = personInfo[2];

                bool isFound = false;
                for(int i = 0; i < persons.Count; i++)
                {
                    if(persons[i].Name == name)
                    {
                        persons[i].Birthday = birthday;
                        isFound = true;
                    }

                    if(persons[i].Birthday == birthday)
                    {
                        persons[i].Name = name;
                        isFound = true;
                    }

                    persons[i].UpdateChiren(new Person(name, birthday));
                }

                if (!isFound)
                {
                    persons.Add(new Person(name, birthday));
                }
                
            }
        }

        StringBuilder sb = new StringBuilder();
        Person personToSearch = null;
        if (personInput.Contains("/"))
        {
            personToSearch = persons.FirstOrDefault(p => p.Birthday == personInput);
        }
        else
        {
            personToSearch = persons.FirstOrDefault(p => p.Name == personInput);
        }

        sb.AppendLine(personToSearch.ToString());

        sb.AppendLine("Parents:");
        
        foreach(var parent in persons.Where(p=> p.Childrens.Contains(personToSearch)))
        {
            sb.AppendLine(parent.ToString());
        }

        sb.AppendLine("Children:");

        foreach (var child in persons.FirstOrDefault(p => p.Name == personToSearch.Name && p.Birthday == personToSearch.Birthday).Childrens)
        {
            sb.AppendLine(child.ToString());
        }

        Console.Write(sb.ToString());
    }
}