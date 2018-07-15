using Newtonsoft.Json;

namespace ProductShop.App.Models
{
    public class UserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonProperty(PropertyName = "SoldProducts")]
        public SoldProductDto[] Sold { get; set; }
    }
}