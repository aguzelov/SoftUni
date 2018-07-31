using CarDealer.Models;
using System;

namespace CarDealer.DataProcessor.Models.Export
{
    public class CustomerExportDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public virtual Sale[] Sales { get; set; } = new Sale[0];
    }
}