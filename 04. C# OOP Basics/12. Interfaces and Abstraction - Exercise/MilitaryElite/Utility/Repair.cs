public class Repair
{
    private string partName;
    private int hoursWorked;

    public string PartName
    {
        get
        {
            return this.partName;
        }
        private set
        {
            this.partName = value;
        }
    }

    public int HoursWorked
    {
        get
        {
            return this.hoursWorked;
        }
        private set
        {
            this.hoursWorked = value;
        }
    }

    public Repair(string partName, int hoursWorked)
    {
        PartName = partName;
        HoursWorked = hoursWorked;
    }

    public override string ToString()
    {
        return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
    }
}