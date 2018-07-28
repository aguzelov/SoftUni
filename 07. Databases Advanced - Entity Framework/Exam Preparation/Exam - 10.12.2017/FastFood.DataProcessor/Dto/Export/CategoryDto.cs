using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FastFood.DataProcessor
{
    [XmlType("Category")]
    public class CategoryDto
    {
        public string Name { get; set; }

        public ItemExportXmlDto MostPopularItem { get; set; }
    }
}