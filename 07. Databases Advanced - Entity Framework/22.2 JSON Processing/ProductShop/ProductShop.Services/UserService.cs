using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Services.Contracts;
using System.Linq;

namespace ProductShop.Services
{
    public class UserService : IUserService
    {
        private readonly ProductShopContext context;

        public UserService(ProductShopContext context)
        {
            this.context = context;
        }

        public void AddRange(User[] users)
        {
            context.Users.AddRange(users);

            context.SaveChanges();
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);

            context.SaveChanges();
        }

        public IQueryable<TModel> GetAllWith<TModel>(int minSoldProductsCount = 1)
        {
            var models = context.Users
                .Include(u => u.Sold)
                .Where(u => u.Sold.Count >= minSoldProductsCount)
                .ProjectTo<TModel>();

            return models;
        }

        public User[] GetAll(int minSoldProductsCount = 1)
        {
            var models = context.Users
                .Include(u => u.Sold)
                .Where(u => u.Sold.Count >= minSoldProductsCount)
                .ToArray();

            return models;
        }
    }
}