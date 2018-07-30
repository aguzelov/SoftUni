using System.Xml.Serialization;

namespace CarDealer.DataProcessor.Models.Import
{
    [XmlType("supplier")]
    public class SupplierImportDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("is-importer")]
        public bool IsImporter { get; set; }
    }
}