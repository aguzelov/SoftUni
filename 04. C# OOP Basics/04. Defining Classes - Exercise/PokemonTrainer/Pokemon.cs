public class Pokemon
{
    public string Name { get; set; }
    public string Element { get; set; }
    public long Health { get; set; }

    public Pokemon(string name, string element, long health)
    {
        Name = name;
        Element = element;
        Health = health;
    }
}
