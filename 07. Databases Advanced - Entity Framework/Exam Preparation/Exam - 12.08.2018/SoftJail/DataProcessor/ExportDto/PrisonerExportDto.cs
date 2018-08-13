using System.Linq;

namespace SoftJail.DataProcessor.ExportDto
{
    public class PrisonerExportDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CellNumber { get; set; }

        public OfficersExportDto[] Officers { get; set; }

        public decimal TotalOfficerSalary => Officers.Sum(o => o.Salary);
    }
}