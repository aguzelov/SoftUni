using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System;
using System.Linq;

namespace PhotoShare.Services
{
    public class TownService : ITownService
    {
        private readonly PhotoShareContext context;

        public TownService(PhotoShareContext context)
        {
            this.context = context;
        }

        public Town AddTown(string townName, string countryName)
        {
            if (Exist(townName))
            {
                Town existedTown = context.Towns.First(t => t.Name == townName);
                throw new ArgumentException($"Town {existedTown} was already added!");
            }

            Town town = new Town
            {
                Name = townName,
                Country = countryName
            };

            context.Towns.Add(town);
            context.SaveChanges();

            return town;
        }

        public bool Exist(string townName)
        {
            return context.Towns.Any(t => t.Name == townName);
        }
    }
}