using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Models;
using Panda.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Panda.Services
{
    public class PackageService : IPackageService
    {
        private readonly ApplicationDbContext context;
        private readonly IAccountService accountService;
        private readonly IMapper mapper;

        public PackageService(ApplicationDbContext context, IAccountService accountService, IMapper mapper)
        {
            this.context = context;
            this.accountService = accountService;
            this.mapper = mapper;
        }

        public IDictionary<string, ICollection<T>> GetUserPackagesByStatus<T>(string username)
        {
            var packageStatuses = Enum.GetValues(typeof(PackageStatus)).Cast<PackageStatus>().ToList();

            var packages = new Dictionary<string, ICollection<T>>();

            foreach (var status in packageStatuses)
            {
                var statusText = status.ToString();

                var currentStatusPackages = this.context.Packages
                    .Where(p => p.Recipient.UserName == username && p.Status == status)
                     .Select(p => this.mapper.Map<T>(p)).ToList();

                packages[statusText] = currentStatusPackages;
            }

            return packages;
        }

        public T GetById<T>(string id)
        {
            var package = this.context.Packages.FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return default(T);
            }

            var model = this.mapper.Map<T>(package);

            return model;
        }

        public string Add(string description, string shippingAddress, float weight, string recipient)
        {
            var user = this.accountService.GetUser<User>(recipient).GetAwaiter().GetResult();
            if (user == null)
            {
                return null;
            }

            var package = new Package
            {
                Status = PackageStatus.Pending,
                EstimatedDeliveryDate = null,
                Description = description,
                ShippingAddress = shippingAddress,
                Weight = weight,
                UserId = user.Id.ToString()
            };

            var id = this.context.Packages.Add(package).Entity.Id;
            this.context.SaveChanges();

            return id;
        }

        public ICollection<T> GetPackagesByStatus<T>(string status)
        {
            IQueryable<Package> query = null;
            if (status == "Delivered")
            {
                query = this.context.Packages
                .Where(p => p.Status.ToString() == status ||
                    p.Status.ToString() == "Acquired");
            }
            else
            {
                query = this.context.Packages
                   .Where(p => p.Status.ToString() == status);
            }

            var packages = query
                .Include(p => p.Recipient)
                .Select(p => this.mapper.Map<T>(p)).ToList();

            return packages;
        }

        public bool Ship(string id)
        {
            var package = this.context.Packages.FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return false;
            }

            package.Status = PackageStatus.Shipped;

            var random = new Random();

            package.EstimatedDeliveryDate = DateTime.Now.AddDays(random.Next(20, 40));

            this.context.SaveChanges();

            return true;
        }

        public bool Deliver(string id)
        {
            var package = this.context.Packages.FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return false;
            }

            package.Status = PackageStatus.Delivered;

            this.context.SaveChanges();

            return true;
        }

        public bool Acquire(string id)
        {
            var package = this.context.Packages.FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return false;
            }

            package.Status = PackageStatus.Acquired;

            var fee = (decimal)(package.Weight * 2.67);

            var receipt = new Receipt
            {
                PackageId = package.Id,
                UserId = package.UserId,
                Fee = fee,
                IssuedOn = DateTime.UtcNow
            };

            this.context.Receipts.Add(receipt);

            this.context.SaveChanges();

            return true;
        }
    }
}