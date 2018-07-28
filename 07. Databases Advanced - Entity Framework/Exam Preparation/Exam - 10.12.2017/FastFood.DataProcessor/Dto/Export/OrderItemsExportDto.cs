using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.DataProcessor
{
    public class OrderItemsExportDto
    {
        public string Customer { get; set; }

        public ItemExportDto[] Items { get; set; }

        public decimal TotalPrice => this.Items.Sum(i => i.Price * i.Quantity);
    }
}