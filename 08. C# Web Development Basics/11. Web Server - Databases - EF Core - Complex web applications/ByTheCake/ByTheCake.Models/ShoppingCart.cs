using ByTheCake.Models;
using System.Collections.Generic;

namespace HTTPServer.ByTheCakeApp.Models
{
    public class ShoppingCart
    {
        public const string SessionKey = "%^Current_Shopping_Cart^%";

        public ShoppingCart()
        {
            this.Orders = new List<Product>();
        }

        public List<Product> Orders { get; private set; }
    }
}