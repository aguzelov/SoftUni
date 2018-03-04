public class War
{
    private static int warCounter = 1;

    private int warNumber;
    private string nation;

    public War(string nationsType)
    {
        warNumber = warCounter++;
        this.nation = nationsType;
    }

    public override string ToString()
    {
        return $"War {this.warNumber} issued by {this.nation}";
    }
}