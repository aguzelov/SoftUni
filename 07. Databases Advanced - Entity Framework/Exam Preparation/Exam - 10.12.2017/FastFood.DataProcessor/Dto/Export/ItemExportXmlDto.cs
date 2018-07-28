using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DataProcessor
{
    public class ItemExportXmlDto
    {
        public string Name { get; set; }

        public decimal TotalMade { get; set; }

        public int TimesSold { get; set; }
    }
}