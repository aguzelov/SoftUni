using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerImportDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.0", "79228162514264337593543950335")]
        [XmlElement("Money")]
        public decimal Money { get; set; }

        [Required]
        [XmlElement("Position")]
        public string Position { get; set; }

        [Required]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public PrisonerOfficerImportDto[] Prisoners { get; set; }
    }
}

/*
 Name>Minerva Kitchingman</Name>
		<Money>2582</Money>
		<Position>Invalid</Position>
		<Weapon>ChainRifle</Weapon>
		<DepartmentId>2</DepartmentId>
		<Prisoners>
			<Prisoner id="15" />
		</Prisoners>
*/