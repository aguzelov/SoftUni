using System.Xml.Serialization;

namespace ProductShop.DataProcessor.Models.Import
{
    [XmlType("category")]
    public class CategoryImportDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}