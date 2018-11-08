using AutoMapper;
using FDMC.Data;
using FDMC.Models;
using FDMC.Service.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace FDMC.Service
{
    public class CatService : ICatService
    {
        private readonly FDMCContext context;
        private readonly IMapper mapper;

        public CatService(FDMCContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool Add(string name, int age, string breed, string imageUrl)
        {
            if (name == null ||
                 breed == null ||
                 imageUrl == null ||
                 age < 0 || age > 30)
            {
                return false;
            }

            var cat = new Cat
            {
                Name = name,
                Age = age,
                Breed = breed,
                ImageUrl = imageUrl
            };

            this.context.Cats.Add(cat);
            this.context.SaveChanges();

            return true;
        }

        public ICollection<T> All<T>()
        {
            var cats = this.context.Cats
                .Select(c => this.mapper.Map<T>(c))
                .ToList();

            return cats;
        }

        public T GetById<T>(int id)
        {
            var cat = this.context.Cats.FirstOrDefault(c => c.Id == id);

            return this.mapper.Map<T>(cat);
        }
    }
}