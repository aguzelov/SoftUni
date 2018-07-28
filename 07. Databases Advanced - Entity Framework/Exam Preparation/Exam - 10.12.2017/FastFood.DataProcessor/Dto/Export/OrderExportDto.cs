using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.DataProcessor
{
    public class OrderExportDto
    {
        public string Name { get; set; }

        public OrderItemsExportDto[] Orders { get; set; }

        public decimal TotalMate => this.Orders.Sum(o => o.TotalPrice);
    }
}