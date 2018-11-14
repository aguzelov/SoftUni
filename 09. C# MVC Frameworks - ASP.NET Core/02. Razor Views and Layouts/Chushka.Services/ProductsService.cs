using AutoMapper;
using Chushka.Data;
using Chushka.Models;
using Chushka.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chushka.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductsService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Create(string name, decimal price, string description, string type)
        {
            if (name == null ||
                price < 0 ||
                description == null ||
                type == null)
                return null;

            var isSucceded = Enum.TryParse(type, out ProductType productType);
            if (!isSucceded)
                return null;

            var product = new Product
            {
                Name = name,
                Price = price,
                Description = description,
                Type = productType
            };

            this.context.Products.Add(product);
            this.context.SaveChanges();

            return product.Id;
        }

        public T Details<T>(string id)
        {
            var product = this.context.Products.Find(id);

            if (product == null)
                return default(T);

            var model = this.mapper.Map<T>(product);

            return model;
        }

        public ICollection<T> GetAll<T>()
        {
            var products = this.context.Products
                .Select(p => this.mapper.Map<T>(p))
                .ToList();

            return products;
        }

        public bool Edit(string id, string name, decimal price, string description, string type)
        {
            if (name == null ||
                price < 0 ||
                description == null ||
                type == null)
                return false;

            var isSucceded = Enum.TryParse(type, out ProductType productType);
            if (!isSucceded)
                return false;

            var product = this.context.Products.Find(id);

            if (product == null)
            {
                return false;
            }

            product.Name = name;
            product.Price = price;
            product.Description = description;
            product.Type = productType;

            this.context.SaveChanges();

            return true;
        }

        public void Delete(string id)
        {
            var product = this.context.Products.Find(id);

            this.context.Products.Remove(product);
            this.context.SaveChanges();
        }
    }
}