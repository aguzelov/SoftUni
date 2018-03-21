using P03.Detail_Printer.Interfaces;

namespace P03.DetailPrinter
{
    public class Employee : IPrintable
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}