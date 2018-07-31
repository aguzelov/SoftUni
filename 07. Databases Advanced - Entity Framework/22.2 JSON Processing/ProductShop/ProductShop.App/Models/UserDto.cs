using Newtonsoft.Json;

namespace ProductShop.App.Models
{
    public class UserDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "soldProducts")]
        public SoldProductDto[] Sold { get; set; }
    }
}