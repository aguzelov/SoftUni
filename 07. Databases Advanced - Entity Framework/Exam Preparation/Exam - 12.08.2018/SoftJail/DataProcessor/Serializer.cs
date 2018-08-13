namespace SoftJail.DataProcessor
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Include(p => p.PrisonerOfficers)
                .ThenInclude(op => op.Officer)
                .ThenInclude(o => o.Department)
                .Select(p => new PrisonerExportDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(o => new OfficersExportDto
                        {
                            OfficerName = o.Officer.FullName,
                            Department = o.Officer.Department.Name,
                            Salary = o.Officer.Salary
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var jsonString = JsonConvert.SerializeObject(prisoners, Newtonsoft.Json.Formatting.Indented);

            return jsonString;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(",").ToArray();

            var prisoners = context.Prisoners
                    .Where(p => names.Contains(p.FullName))
                    .Select(p => new PrisonerInboxEportDto
                    {
                        Id = p.Id,
                        Name = p.FullName,
                        IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                        EncryptedMessages = p.Mails
                                .Select(m => new MessageExportDto
                                {
                                    Description = Reverse(m.Description)
                                })
                                .ToArray()
                    })
                    .OrderBy(p => p.Name)
                    .ThenBy(p => p.Id)
                    .ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(PrisonerInboxEportDto[]), new XmlRootAttribute("Prisoners"));
            serializer.Serialize(new StringWriter(sb), prisoners, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            var result = sb.ToString();
            return result;
        }

        private static string Reverse(string input)
        {
            if (input == null) return null;

            // this was posted by petebob as well
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
    }
}