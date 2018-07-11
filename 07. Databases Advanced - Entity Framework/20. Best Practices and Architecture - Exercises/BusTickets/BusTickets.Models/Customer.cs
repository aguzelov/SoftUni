using System;
using System.Collections.Generic;

namespace BusTickets.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public int HomeTownId { get; set; }
        public Town HomeTown { get; set; }

        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}