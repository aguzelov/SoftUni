using SIS.Data;
using SIS.Models;
using System.Collections.Generic;
using System.Linq;

namespace SIS.Services.ShoppingServices
{
    public class ShoppingService : IShoppingService
    {
        private readonly ByTheCakeContext _context;

        public ShoppingService(ByTheCakeContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            this._context.Orders.Add(order);
            this._context.SaveChanges();
        }

        public ICollection<Order> GetOrderByUserId(int id)
        {
            var order = this._context.Orders
                .Where(o => o.UserId == id)
                .ToList();

            return order;
        }

        public Order GetOrderById(int id)
        {
            var order = this._context.Orders.FirstOrDefault(o => o.Id == id);

            return order;
        }
    }
}