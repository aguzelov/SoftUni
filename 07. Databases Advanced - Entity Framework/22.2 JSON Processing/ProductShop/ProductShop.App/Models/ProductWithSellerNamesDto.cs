using Newtonsoft.Json;

namespace ProductShop.App.Models
{
    public class ProductWithSellerNamesDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("seller")]
        public string SellerFullName
        {
            get
            {
                return this.SellerFirstName == null ? this.SellerLastName : this.SellerFirstName + " " + this.SellerLastName;
            }
            set
            {
                this.SellerFullName = value;
            }
        }

        [JsonIgnore]
        public string SellerFirstName { get; set; }

        [JsonIgnore]
        public string SellerLastName { get; set; }
    }
}