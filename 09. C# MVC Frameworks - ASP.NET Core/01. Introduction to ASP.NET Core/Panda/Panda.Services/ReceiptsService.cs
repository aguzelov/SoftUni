using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Panda.Services
{
    public class ReceiptsService : IReceiptsService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ReceiptsService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public T Details<T>(string id)
        {
            var receipt = this.context.Receipts
                .FirstOrDefault(r => r.Id == id);

            var view = this.mapper.Map<T>(receipt);

            return view;
        }

        public ICollection<T> GetUserReceipts<T>(string username)
        {
            var receipts = this.context.Receipts
                .Include(r => r.Recipient)
                .Where(r => r.Recipient.UserName == username)
                .Select(r => this.mapper.Map<T>(r)).ToList();

            return receipts;
        }
    }
}