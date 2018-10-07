using SIS.Models;
using System.Collections.Generic;

namespace SIS.App.Models
{
    public class ShoppingCart
    {
        public static string SessionKey = "%^Current_Shopping_Cart^%";

        public ShoppingCart()
        {
            this.Products = new List<Product>();
        }

        public List<Product> Products { get; private set; }
    }
}