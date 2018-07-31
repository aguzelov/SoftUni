using Newtonsoft.Json;
using System;

namespace CarDealer.DataProcessor.Models.Export
{
    public class SalesWithAppliedDiscountExportDto
    {
        private decimal discount;

        [JsonProperty("car")]
        public CarAndDistanceAttributeExportDto Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        public string Discount
        {
            get
            {
                return this.discount.ToString("F2");
            }
            set
            {
                this.discount = Convert.ToDecimal(value);
            }
        }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("priceWithDiscount")]
        public string PriceWithDiscount
        {
            get
            {
                return (this.Price - (this.Price * (decimal)this.discount)).ToString("F2");
            }
            set
            {
                PriceWithDiscount = value;
            }
        }
    }
}