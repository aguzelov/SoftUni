namespace ProductShop.App.Models
{
    public class ProductWithSellerNamesDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string SellerFirstName { get; set; }

        public string SellerLastName { get; set; }
    }
}