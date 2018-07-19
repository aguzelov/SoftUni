namespace PetClinic.DataProcessor
{
    using Newtonsoft.Json;
    using PetClinic.App.Models;
    using PetClinic.Data;
    using PetClinic.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var animalAids = JsonConvert.DeserializeObject<AnimalAidDto[]>(jsonString);

            var sb = new StringBuilder();

            var validAnimalAid = new List<AnimalAid>();
            foreach (var dto in animalAids)
            {
                if (!IsValid(dto) ||
                    validAnimalAid.Any(a => a.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var animalAid = new AnimalAid
                {
                    Name = dto.Name,
                    Price = dto.Price
                };

                validAnimalAid.Add(animalAid);

                sb.AppendLine($"Record {dto.Name} successfully imported.");
            }

            context.AnimalAids.AddRange(validAnimalAid);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var animals = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var validAnimals = new List<Animal>();
            var serialNumbers = new List<string>();
            foreach (var dto in animals)
            {
                if (!IsValid(dto) || !IsValid(dto.Passport) ||
                    serialNumbers.Any(s => s.Equals(dto.Passport.SerialNumber, StringComparison.OrdinalIgnoreCase)))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                DateTime registraionDate;
                var isRegDateValid = DateTime.TryParse(dto.Passport.RegistrationDate, out registraionDate);

                Passport passport = new Passport
                {
                    SerialNumber = dto.Passport.SerialNumber,
                    OwnerName = dto.Passport.OwnerName,
                    OwnerPhoneNumber = dto.Passport.OwnerPhoneNumber,
                    RegistrationDate = registraionDate
                };

                serialNumbers.Add(passport.SerialNumber);

                Animal animal = new Animal
                {
                    Name = dto.Name,
                    Type = dto.Type,
                    Age = dto.Age,
                    Passport = passport
                };

                validAnimals.Add(animal);

                sb.AppendLine($"Record {animal.Name} Passport №: {animal.Passport.SerialNumber} successfully imported.");
            }

            context.Animals.AddRange(validAnimals);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(VetDto[]), new XmlRootAttribute("Vets"));
            var vets = (VetDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();
            var validVets = new List<Vet>();
            foreach (var dto in vets)
            {
                if (!IsValid(dto) ||
                    validVets.Any(v => v.PhoneNumber.Equals(dto.PhoneNumber, StringComparison.OrdinalIgnoreCase)))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var vet = new Vet
                {
                    Name = dto.Name,
                    Profession = dto.Profession,
                    Age = dto.Age,
                    PhoneNumber = dto.PhoneNumber
                };

                validVets.Add(vet);

                sb.AppendLine($"Record {vet.Name} successfully imported.");
            }

            context.Vets.AddRange(validVets);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ProcedureDto[]), new XmlRootAttribute("Procedures"));
            var procedures = (ProcedureDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();
            var validProcedure = new List<Procedure>();

            foreach (var dto in procedures)
            {
                if (!IsValid(dto) ||
                    dto.AnimalAids.Length != dto.AnimalAids.Select(a => a.Name).Distinct().Count())
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var vet = context.Vets
                    .FirstOrDefault(v => v.Name.Equals(dto.VetName, StringComparison.OrdinalIgnoreCase));
                if (vet == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var animal = context.Animals
                    .FirstOrDefault(a => a.PassportSerialNumber.Equals(dto.AnimalSerialNumber, StringComparison.OrdinalIgnoreCase));
                if (animal == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var animalAids = context.AnimalAids
                    .Where(a => dto.AnimalAids.Any(dtoa => dtoa.Name.Equals(a.Name, StringComparison.OrdinalIgnoreCase)))
                    .ToArray();
                if (animalAids.Length != dto.AnimalAids.Length)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var proceduresAnimalAids = new List<ProcedureAnimalAid>();
                foreach (var aid in animalAids)
                {
                    proceduresAnimalAids.Add(new ProcedureAnimalAid
                    {
                        AnimalAidId = aid.Id
                    });
                }

                DateTime procedureDate;
                var isProcDateValid = DateTime.TryParseExact(dto.ProcedureDate,
                    "dd-MM-yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out procedureDate);

                var procedure = new Procedure
                {
                    Vet = vet,
                    Animal = animal,
                    DateTime = procedureDate,
                    ProcedureAnimalAids = proceduresAnimalAids
                };

                validProcedure.Add(procedure);

                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(validProcedure);
            context.SaveChanges();

            string result = sb.ToString();
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