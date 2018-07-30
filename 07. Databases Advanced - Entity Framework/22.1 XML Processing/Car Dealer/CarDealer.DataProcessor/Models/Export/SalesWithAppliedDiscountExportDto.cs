using System;
using System.Xml.Serialization;

namespace CarDealer.DataProcessor.Models.Export
{
    [XmlType("sale")]
    public class SalesWithAppliedDiscountExportDto
    {
        private decimal discount;

        [XmlElement("car")]
        public CarAndDistanceAttributeExportDto Car { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("discount")]
        public string Dicount
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

        [XmlElement("Price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
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