namespace PetClinic.DataProcessor
{
    using PetClinic.Data;
    using PetClinic.Models;
    using System;
    using System.Linq;

    public class Bonus
    {
        private const string ProfesionUpdate = "{0}'s profession updated from {1} to {2}.";
        private const string VetNotFound = "Vet with phone number {0} not found!";

        public static string UpdateVetProfession(PetClinicContext context, string phoneNumber, string newProfession)
        {
            Vet vet = context.Vets.SingleOrDefault(v => v.PhoneNumber == phoneNumber);

            if (vet == null)
            {
                return String.Format(VetNotFound, phoneNumber);
            }

            string oldProfession = vet.Profession;

            vet.Profession = newProfession;

            context.SaveChanges();

            return String.Format(ProfesionUpdate, vet.Name, oldProfession, vet.Profession);
        }
    }
}