using System.Collections.Generic;

namespace P02_DatabaseFirst.Data.Models
{
    public class Address
    {
        public Address()
        {
        }

        public int AddressId { get; set; }
        public string AddressText { get; set; }

        public int? TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}