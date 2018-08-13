namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string SuccessDepartmentMessage = "Imported {0} with {1} cells";
        private const string SuccessPrisonerMessage = "Imported {0} {1} years old";
        private const string SuccessOfficerMessage = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var deparmentCells = JsonConvert.DeserializeObject<DepartmentCellsImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var deparments = new List<Department>();

            foreach (var dto in deparmentCells)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidCell = true;
                var cells = new List<Cell>();
                foreach (var cellDto in dto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        isValidCell = false;
                        break;
                    }

                    var cell = new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };

                    cells.Add(cell);
                }

                if (!isValidCell)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var deparment = new Department
                {
                    Name = dto.Name,
                    Cells = cells
                };

                deparments.Add(deparment);

                sb.AppendLine(String.Format(SuccessDepartmentMessage, deparment.Name, deparment.Cells.Count));
            }

            context.Departments.AddRange(deparments);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonerDtos = JsonConvert.DeserializeObject<PrisonerImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var prisoners = new List<Prisoner>();

            foreach (var dto in prisonerDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidMail = true;
                var mails = new List<Mail>();
                foreach (var mailDto in dto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        isValidMail = false;
                        break;
                    }

                    var mail = new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    };

                    mails.Add(mail);
                }

                if (!isValidMail)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var incarcerationDate = DateTime.ParseExact(dto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                DateTime? releaseDate = null;
                if (dto.ReleaseDate != null)
                {
                    releaseDate = DateTime.ParseExact(dto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                if (dto.Bail == null)
                {
                    Console.WriteLine();
                }

                var prisoner = new Prisoner
                {
                    FullName = dto.FullName,
                    Nickname = dto.Nickname,
                    Age = dto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = dto.Bail,
                    CellId = dto.CellId,
                    Mails = mails
                };

                prisoners.Add(prisoner);

                sb.AppendLine(String.Format(SuccessPrisonerMessage, prisoner.FullName, prisoner.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OfficerImportDto[]), new XmlRootAttribute("Officers"));
            var dtos = (OfficerImportDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();
            var officers = new List<Officer>();
            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidPosition = Enum.TryParse(typeof(Position), dto.Position, out object positionResult);
                var isValidWeapon = Enum.TryParse(typeof(Weapon), dto.Weapon, out object weaponResult);

                if (!isValidPosition || !isValidWeapon)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var position = (Position)positionResult;
                var weapon = (Weapon)weaponResult;

                var officersPrisoners = new List<OfficerPrisoner>();
                foreach (var prisoner in dto.Prisoners)
                {
                    var officerPrisoner = new OfficerPrisoner
                    {
                        PrisonerId = prisoner.Id
                    };

                    officersPrisoners.Add(officerPrisoner);
                }

                var officer = new Officer
                {
                    FullName = dto.Name,
                    Salary = dto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = dto.DepartmentId,
                    OfficerPrisoners = officersPrisoners
                };

                officers.Add(officer);

                sb.AppendLine(String.Format(SuccessOfficerMessage, officer.FullName, officer.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}