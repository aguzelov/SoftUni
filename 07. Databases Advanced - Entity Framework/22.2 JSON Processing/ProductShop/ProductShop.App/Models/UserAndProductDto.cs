using Newtonsoft.Json;

namespace ProductShop.App.Models
{
    public class UserAndProductDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        [JsonProperty(PropertyName = "SoldProducts")]
        public ProductNameAndPriceDto[] Sold { get; set; }
    }
}