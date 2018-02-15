public class Cat
{
    public string Breed { get; set; }
    public string Name { get; set; }

    public Cat(string breed,string name)
    {
        Breed = breed;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Breed} {Name}";
    }
}