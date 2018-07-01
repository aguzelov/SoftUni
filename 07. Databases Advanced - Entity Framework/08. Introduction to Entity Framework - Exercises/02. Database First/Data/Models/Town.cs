using System.Collections.Generic;

namespace P02_DatabaseFirst.Data.Models
{
    public class Town
    {
        public Town()
        {
        }

        public int TownId { get; set; }
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}