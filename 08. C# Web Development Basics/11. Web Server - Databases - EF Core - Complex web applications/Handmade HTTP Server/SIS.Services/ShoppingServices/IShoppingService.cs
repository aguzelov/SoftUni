using SIS.Models;
using System.Collections.Generic;

namespace SIS.Services.ShoppingServices
{
    public interface IShoppingService
    {
        void Add(Order order);

        ICollection<Order> GetOrderByUserId(int id);

        Order GetOrderById(int id);
    }
}