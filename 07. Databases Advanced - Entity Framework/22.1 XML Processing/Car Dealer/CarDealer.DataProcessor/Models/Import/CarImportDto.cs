using System.Xml.Serialization;

namespace CarDealer.DataProcessor.Models.Import
{
    [XmlType("car")]
    public class CarImportDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long Distance { get; set; }
    }
}

//<car>
//    <make>Opel</make>
//    <model>Omega</model>
//    <travelled-distance>2147483647</travelled-distance>
//</car>