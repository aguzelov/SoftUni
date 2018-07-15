using Newtonsoft.Json;

namespace ProductShop.App.Models
{
    public class CategoryByProductsDto
    {
        [JsonProperty(PropertyName = "Category")]
        public string Category { get; set; }

        public int ProductsCount { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}