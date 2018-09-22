using System.Collections.Generic;

namespace HTTPServer.ByTheCakeApp.Models
{
    public class ShoppingCart
    {
        public const string SessionKey = "%^Current_Shopping_Cart^%";

        public ShoppingCart()
        {
            this.Orders = new List<Cake>();
        }

        public List<Cake> Orders { get; private set; }
    }
}